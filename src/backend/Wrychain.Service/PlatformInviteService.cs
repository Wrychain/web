using Wrychain.DAL.Entity.Invites;
using Wrychain.DAL.Repository;
using System.Security.Cryptography;

namespace Wrychain.Service;

public class PlatformInviteService
{
    private readonly PlatformInviteRepository _platformInviteRepository;

    public PlatformInviteService(PlatformInviteRepository platformInviteRepository)
    {
        _platformInviteRepository = platformInviteRepository;
    }

    public string GenerateToken()
    {
        string tokenHash;

        // Generate and hash entropy
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[32];
            rng.GetBytes(randomBytes);
            byte[] hashBytes = SHA256.HashData(randomBytes);
            tokenHash = System.Text.Encoding.UTF8.GetString(hashBytes, 0, 32);
        }

        // Create invite
        PlatformInvite invite = new PlatformInvite
        {
            SenderId = 1,
            TokenHash = tokenHash
        };
        _platformInviteRepository.Add(invite);
        _platformInviteRepository.Save();

        return tokenHash;
    }

    public bool ValidateToken(string tokenHash)
    {
        PlatformInvite? invite = _platformInviteRepository.FindOneBy(invite => invite.TokenHash == tokenHash);

        // Not found case
        if (invite == null)
        {
            return false;
        }

        // Expired case
        if (DateTime.Now < invite.ExpiresAt)
        {
            return false;
        }

        // Previously used case
        if (invite.IsActive == false)
        {
            return false;
        }

        return true;
    }
}
