using Caspnetti.DAL.Entity.Invites;
using Caspnetti.DAL.Repository;
using Caspnetti.Service;
using Microsoft.AspNetCore.Mvc;

namespace Caspnetti.API.Controllers;

[ApiController]
[Route("api/invite/")]
public class InviteController : ControllerBase
{
    private readonly PlatformInviteService _platformInviteService;

    public InviteController(PlatformInviteService platformInviteService)
    {
        _platformInviteService = platformInviteService;
    }

    [HttpGet("platform/check")]
    public IActionResult CheckToken(string token)
    {
        bool result = _platformInviteService.ValidateToken(token);

        if (result)
        {
            return this.Content("{\"valid\": true}", "application/json");
        }
        else
        {
            return this.Content("{\"valid\": false}", "application/json");
        }
    }
}
