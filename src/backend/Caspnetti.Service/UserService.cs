using Caspnetti.DAL.Entity.Users;
using Caspnetti.DAL.Repository;
using System.Collections.Generic;

namespace Caspnetti.Service;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<User> Test()
    {
        var users = _userRepository.FindAll();
        return users;
    }
}
