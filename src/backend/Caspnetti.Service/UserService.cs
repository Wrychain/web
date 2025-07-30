using Caspnetti.DAL.Entity.Users;
using Caspnetti.DAL.Repository;
using System.Security.Cryptography;

namespace Caspnetti.Service;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool Register(string platformToken, User incomingUser)
    {
        return true;
    }

    public IEnumerable<User> Test()
    {
        var users = _userRepository.FindAll();
        return users;
    }
}
