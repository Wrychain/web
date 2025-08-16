using Microsoft.Extensions.Caching.Distributed;
using System.Security.Cryptography;
using System.Text.Json;
using Wrychain.DAL.Entity.Invites;
using Wrychain.DAL.Entity.Users;
using Wrychain.DAL.Repository;

namespace Wrychain.Service;

public class UserService
{
    private readonly LoginSessionRepository _loginSessionRepository;
    private readonly PlatformInviteRepository _platformInviteRepository;
    private readonly PlatformInviteService _platformInviteService;
    private readonly UserRepository _userRepository;
    private readonly IDistributedCache _cache;

    private readonly int _saltSize = 32;
    private readonly int _sessionTokenSize = 32;

    public UserService(LoginSessionRepository loginSessionRepository, PlatformInviteRepository platformInviteRepository, UserRepository userRepository, PlatformInviteService platformInviteService, IDistributedCache cache)
    {
        _loginSessionRepository = loginSessionRepository;
        _platformInviteRepository = platformInviteRepository;
        _platformInviteService = platformInviteService;
        _userRepository = userRepository;
        _cache = cache;
    }

    public bool Register(string username, string displayName, string password, string tokenHash)
    {
        // Validate user provided tokenHash
        bool validationResult = _platformInviteService.ValidateToken(tokenHash);

        // Bad token case
        if (validationResult == false)
        {
            return false;
        }

        // Taken username case
        if (_userRepository.FindOneBy(user => user.Username == username) != null)
        {
            return false;
        }

        // Assemble and persist user
        byte[] salt = this.GenerateSalt();
        string passwordHash = this.HashPassword(salt, password);
        User user = new User()
        {
            Username = username,
            PasswordHash = passwordHash,
            DisplayName = displayName,
        };
        _userRepository.Add(user);
        _userRepository.Save();

        // TODO: Prevent querying the invite a second time in the future
        // Inactivate invite and attach created user's id
        PlatformInvite invite = _platformInviteRepository.FindOneBy(invite => invite.TokenHash == tokenHash)!;
        invite.ReceiverId = user.Id;
        invite.IsActive = false;
        _platformInviteRepository.Save();

        return true;
    }

    public bool Login(string username, string password)
    {
        // Lookup user by username and obtain stored passwordHash
        User? user = _userRepository.FindOneBy(user => user.Username == username);

        // User not found case
        if (user == null)
        {
            return false;
        }

        // Create login attempt record
        // TODO: Add more detail to LoginAttempt entity
        LoginAttempt newLoginAttempt = new LoginAttempt();
        user.LoginAttempts!.Add(newLoginAttempt);
        _userRepository.Update(user);
        _userRepository.Save();

        // Validate provided password against stored passwordHash
        bool passwordsMatch = this.ValidatePassword(password, user.PasswordHash);

        // Passwords do not match case
        if (passwordsMatch == false) 
        {
            return false;
        }

        // Create login session
        string sessionToken = this.GenerateSessionToken();
        LoginSession newLoginSession = new LoginSession()
        {
            UserId = user.Id,
            Token = sessionToken,
            // TODO: modify arguments or where this logic occurs to source:
            // - IPAddress
            // - UserAgent
            ExpiresAt = DateTime.Now.AddDays(30),
            IsActive = true
        };
        _loginSessionRepository.Add(newLoginSession);
        _loginSessionRepository.Save();

        // Set session token in cache
        var session = new
        {
            UserId = user.Id,
            LoginSessionId = newLoginSession.Id,
            ExpiresAt = newLoginSession.ExpiresAt
        };
        _cache.SetString(sessionToken, JsonSerializer.Serialize(session));

        return true;
    }

    public bool ValidateSessionToken(string sessionToken)
    {
        LoginSession? loginSession = _loginSessionRepository.FindOneBy(s => s.Token == sessionToken);
    
        if (loginSession == null)
        {
            return false;
        }

        if (loginSession.IsActive == false)
        {
            return false;
        }

        if (loginSession.ExpiresAt < DateTime.Now)
        {
            return false;
        }

        return true;
    }

    public byte[] GenerateSalt()
    {
        return RandomNumberGenerator.GetBytes(_saltSize);
    }

    public string GenerateSessionToken()
    {
        byte[] bytes = RandomNumberGenerator.GetBytes(_sessionTokenSize);
        return Convert.ToBase64String(bytes)
            .Replace("+", "-")
            .Replace("/", "_")
            .Replace("=", "");
    }

    public string HashPassword(byte[] salt, string password)
    {
        // Generate one-way password hash using salt
        using Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        // Combine and return passwordHash (salt + hash)
        byte[] result = new byte[salt.Length + hash.Length];
        Buffer.BlockCopy(salt, 0, result, 0, salt.Length);
        Buffer.BlockCopy(hash, 0, result, salt.Length, hash.Length);
        return System.Convert.ToBase64String(result);
    }

    public bool ValidatePassword(string password, string passwordHash)
    {
        // Extract salt
        byte[] passwordHashBytes = System.Convert.FromBase64String(passwordHash);
        byte[] salt = new byte[_saltSize];
        Buffer.BlockCopy(passwordHashBytes, 0, salt, 0, _saltSize);

        // Generate password hash with incoming password and extracted salt
        string generatedPasswordHash = this.HashPassword(salt, password);

        // PasswordHashes do not match case
        if (generatedPasswordHash != passwordHash)
        {
            return false;
        }

        return true;
    }
}
