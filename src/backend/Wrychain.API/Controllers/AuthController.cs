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
[Route("api/")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Prevent needless login checks by first checking if session token is populated and valid.
        string? token = HttpContext.Session.GetString("token");
        if (token != null)
        {
            bool isTokenValid = _userService.ValidateSessionToken(token);
            if (isTokenValid)
            {
                return this.Content("{\"skip\": true}", "application/json");
            }
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
            return this.Content("{\"valid\": false}", "application/json");
        }

        // A user was found. Add a login attempt record.
        _userService.AddLoginAttempt(user, remoteIPAddress, userAgent);

        // Do the passwords match?
        bool passwordValid = _userService.ValidatePassword(password, user.PasswordHash);
        if (passwordValid == false)
        {
            return this.Content("{\"valid\": false}", "application/json");
        }

        // Supplied password was correct. Add and register a login session record.
        LoginSession newLoginSession = _userService.AddLoginSession(user, remoteIPAddress, userAgent);
        HttpContext.Session.SetString("token", newLoginSession.Token);

        return this.Content("{\"valid\": true}", "application/json");
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        // Prevent needless login checks by first checking if session token is populated and valid.
        string? token = HttpContext.Session.GetString("token");
        if (token != null)
        {
            bool isTokenValid = _userService.ValidateSessionToken(token);
            if (isTokenValid)
            {
                return this.Content("{\"skip\": true}", "application/json");
            }
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
            return this.Content("{\"valid\": false}", "application/json");
        }

        // Validate the username is not already taken.
        User? user = _userService.GetUser(username);
        if (user != null)
        {
            return this.Content("{\"valid\": false}", "application/json");
        }

        // Get platform invite by value and validate.
        PlatformInvite? invite = _userService.GetPlatformInvite(platformToken);

        // Invite does not exist case.
        if (invite == null)
        {
            return this.Content("{\"valid\": false}", "application/json");
        }

        // Invite is not active case.
        if(invite.IsActive == false)
        {
            return this.Content("{\"valid\": false}", "application/json");
        }

        // Invite is expired case.
        if(invite.ExpiresAt < DateTime.Now)
        {
            // Mark token as expired, as it is currently active.
            _userService.SetPlatformInviteAsInActive(invite);
            return this.Content("{\"valid\": false}", "application/json");
        }

        // Validation passed, invoke CreateUser method
        _userService.CreateUser(username, displayName, password, invite);

        return this.Content("{\"valid\": true}", "application/json");
    }
}
