using Caspnetti.DAL.Entity.Users;
using Caspnetti.DAL.Repository;
using System.Security.Cryptography;

namespace Caspnetti.Service;

public class UserService
{
    private readonly PlatformInviteRepository _platformInviteRepository;
    private readonly PlatformInviteService _platformInviteService;
    private readonly UserRepository _userRepository;

    private readonly int _saltSize = 32;

    public UserService(PlatformInviteRepository platformInviteRepository, UserRepository userRepository, PlatformInviteService platformInviteService)
    {
        _platformInviteRepository = platformInviteRepository;
        _platformInviteService = platformInviteService;
        _userRepository = userRepository;
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
        if (_userRepository.FindOneBy(user => user.username == username) != null)
        {
            return false;
        }

        // Assemble and persist user
        byte[] salt = this.GenerateSalt();
        string passwordHash = this.HashPassword(salt, password);
        User user = new User()
        {
            Username = username,
            Salt = salt,
            PasswordHash = passwordHash,
            DisplayName = displayName,
        };
        _userRepository.Add(user);
        _userRepository.Save();

        // TODO: Prevent quering the invite a second time in the future
        // Inactivate invite and attach created user's id
        PlatformInvite? invite = _platformInviteRepository.FindOneBy(invite => invite.TokenHash == tokenHash);
        invite.ReceiverId = user.Id;
        invite.IsActive = false;
        _platformInviteRepository.Save();

        return true;
    }

    public bool Login(string username, string password)
    {
        // Lookup user by username and obtain stored passwordHash
        User? user = _userRepository.FindOneBy(user => user.username == username);

        if (user == null)
        {
            return false;
        }

        return this.ValidatePassword(password, user.PasswordHash);
    }

    public byte[] GenerateSalt()
    {
        return RandomNumberGenerator.GetBytes(_saltSize);
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

        string generatedPasswordHash = this.HashPassword(salt, password);

        // PasswordHashes do not match case
        if (generatedPasswordHash != passwordHash)
        {
            return false;
        }

        return true;
    }
}
