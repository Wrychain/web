using Caspnetti.DAL;
using Caspnetti.DAL.Repository;
using Caspnetti.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Caspnetti.API.Controllers;

public class BaseController<TRepo, TEntity> : ControllerBase
where TRepo : IRepository<TEntity>
where TEntity : class, IEntity
{
    protected readonly TRepo _repository;

    public BaseController(TRepo repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public virtual IEnumerable<TEntity> Index()
    {
        return _repository.FindAll();
    }

    [HttpGet("{id}")]
    public virtual TEntity? Show(int id)
    {
        return _repository.FindOneBy(e => e.Id == id);
    }

    [HttpPost]
    public virtual int? Create([FromBody] TEntity newEntity)
    {
        _repository.Add(newEntity);
        _repository.Save();
        return newEntity.Id;
    }

    [HttpPut("{id}")]
    public virtual bool Update(int id, [FromBody] TEntity updatedEntity)
    {
        var existing = _repository.FindOneBy(e => e.Id == id);
        if (existing == null)
        {
            return false;
        }

        _repository.Update(updatedEntity);
        _repository.Save();
        return true;
    }

    [HttpDelete("{id}")]
    public virtual bool Delete(int id)
    {
        var existing = _repository.FindOneBy(e => e.Id == id);
        if (existing == null)
        {
            return false;
        }

        _repository.Delete(existing);
        _repository.Save();
        return true;
    }
}
