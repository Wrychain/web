using Wrychain.DAL.Entity.Users;
using Wrychain.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Wrychain.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : BaseController<UserRepository, User>
{
    public UserController(UserRepository repository) : base(repository) { }

    [HttpGet("check")]
    public IActionResult CheckUsername(string username)
    {
        User? result = _repository.FindOneBy(user => user.Username == username);

        if (result == null)
        {
            return this.Content("{\"available\": true}", "application/json");
        }
        else
        {
            return this.Content("{\"available\": false}", "application/json");
        }
    }
}
