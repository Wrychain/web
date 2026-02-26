using Wrychain.API.DTO;
using Wrychain.DAL;
using Wrychain.DAL.Entity.Invites;
using Wrychain.DAL.Entity.Users;
using Wrychain.DAL.Repository;
using Wrychain.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Wrychain.API.Controllers;

[ApiController]
[Route("api/auth/")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    private bool UserIsAuthenticated()
    {
        string? token = HttpContext.Session.GetString("token");

        if (token != null)
        {
            bool isTokenValid = _userService.ValidateSessionToken(token);

            if (isTokenValid)
            {
                return true;
            }
        }

        return false;
    }

    [HttpGet("check")]
    public IActionResult Check()
    {
        return new JsonResult(new { authenticated = this.UserIsAuthenticated() });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Prevent needless login checks by first checking if session token is populated and valid.
        if(this.UserIsAuthenticated())
        {
            return new JsonResult(new { authenticated = true, valid = false });
        }

        // Extract username, password, forwarded IP, and browser's declared user agent.
        // - Reverse proxy setup copies initial incoming remote IP to X-Forwarded-For header
        string username = request.Username;
        string password = request.Password;
        string remoteIPAddress = HttpContext.Request.Headers["X-Forwarded-For"].ToString();
        string userAgent = HttpContext.Request.Headers["User-Agent"].ToString();

        // Get user entity.
        User? user = _userService.GetUser(username);

        // No user found with that username case.
        if (user == null)
        {
            return new JsonResult(new { valid = false });
        }

        // A user was found. Add a login attempt record.
        _userService.AddLoginAttempt(user, remoteIPAddress, userAgent);

        // Do the passwords match?
        bool passwordValid = _userService.ValidatePassword(password, user.PasswordHash);
        if (passwordValid == false)
        {
            return new JsonResult(new { valid = false });
        }

        // Supplied password was correct. Add and register a login session record.
        LoginSession newLoginSession = _userService.AddLoginSession(user, remoteIPAddress, userAgent);
        HttpContext.Session.SetString("token", newLoginSession.Token);

        return new JsonResult(new { authenticated = true, valid = true });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        // Prevent needless login checks by first checking if session token is populated and valid.
        if(this.UserIsAuthenticated())
        {
            return new JsonResult(new { authenticated = true, valid = false });
        }

        // Extract username, display name, password, confirm password, token, forwarded IP, and browser's declared user agent.
        // - Reverse proxy setup copies initial incoming remote IP to X-Forwarded-For header
        string username = request.Username;
        string displayName = request.DisplayName;
        string password = request.Password;
        string confirmPassword = request.ConfirmPassword;
        string platformToken = request.Token;

        // TODO:
        // Not really sure if this is needed, but it was copied
        // string remoteIPAddress = HttpContext.Request.Headers["X-Forwarded-For"].ToString();
        // string userAgent = HttpContext.Request.Headers["User-Agent"].ToString();

        // Validate passwords match.
        if (password != confirmPassword)
        {
            return new JsonResult(new { valid = false });
        }

        // Validate the username is not already taken.
        User? user = _userService.GetUser(username);
        if (user != null)
        {
            return new JsonResult(new { valid = false });
        }

        // Get platform invite by value and validate.
        PlatformInvite? invite = _userService.GetPlatformInvite(platformToken);

        // Invite does not exist case.
        if (invite == null)
        {
            return new JsonResult(new { valid = false });
        }

        // Invite is not active case.
        if(invite.IsActive == false)
        {
            return new JsonResult(new { valid = false });
        }

        // Invite is expired case.
        if(invite.ExpiresAt < DateTime.Now)
        {
            // Mark token as expired, as it is currently active.
            _userService.SetPlatformInviteAsInActive(invite);
            return new JsonResult(new { valid = false });
        }

        // Validation passed, invoke CreateUser method
        _userService.CreateUser(username, displayName, password, invite);

        return new JsonResult(new { valid = true });
    }
}
