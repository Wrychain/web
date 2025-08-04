using Wrychain.DAL.Entity.Invites;
using Wrychain.DAL.Repository;
using Wrychain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Wrychain.API.Controllers;

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
