using Wrychain.DAL;
using Wrychain.DAL.Repository;
using Wrychain.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Wrychain.API.Controllers;

public class BaseAuthController<TRepo, TEntity> : BaseController<TRepo, TEntity>
where TRepo : IRepository<TEntity>
where TEntity : class, IEntity
{
    private readonly UserService _userService;

    public BaseAuthController(UserService userService)
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

    [HttpGet]
    public virtual IActionResult Index()
    {
        if (!UserIsAuthenticated())
        {
            return RedirectToAction("Login");
        }

        return base.Index();
    }

    [HttpGet("{id}")]
    public virtual IActionResult Show(int id)
    {
        if (!UserIsAuthenticated())
        {
            return RedirectToAction("Login");
        }

        return base.Show(id);
    }

    [HttpPost]
    public virtual IActionResult Create([FromBody] TEntity newEntity)
    {
        if (!UserIsAuthenticated())
        {
            return RedirectToAction("Login");
        }

        return base.Create(newEntity);
    }

    [HttpPut("{id}")]
    public virtual IActionResult Update(int id, [FromBody] TEntity updatedEntity)
    {
        if (!UserIsAuthenticated())
        {
            return RedirectToAction("Login");
        }

        return base.Update(id, updatedEntity);
    }

    [HttpDelete("{id}")]
    public virtual IActionResult Delete(int id)
    {
        if (!UserIsAuthenticated())
        {
            return RedirectToAction("Login");
        }

        return base.Delete(id);
    }
}
