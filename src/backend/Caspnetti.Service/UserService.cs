using Caspnetti.DAL.Entity.Users;
using Caspnetti.DAL.Repository;
using System.Security.Cryptography;

namespace Caspnetti.Service;

public class UserService
{
    private readonly PlatformInviteService _platformInviteService;
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _platformInviteService = platformInviteService;
        _userRepository = userRepository;
    }

    public bool Register(User incomingUser, string tokenHash)
    {
        bool validationResult = _platformInviteService.Validate(tokenHash);

        // Bad token case
        if (validationResult == false)
        {
            return false;
        }

        // Add user
        _userRepository.Add(incomingUser);
        _userRepository.Save();

        // TODO: Prevent quering the invite a second time in the future
        PlatformInvite? invite = _platformInviteRepository.FindOneBy(invite => invite.TokenHash == tokenHash);
        invite.ReceiverId = incomingUser.Id;
        invite.IsActive = false;
        _platformInviteRepository.Save();

        return true;
    }
}
