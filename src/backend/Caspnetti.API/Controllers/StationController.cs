using Caspnetti.DAL.Entity.Stations;
using Caspnetti.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Caspnetti.API.Controllers;

[ApiController]
[Route("api/station")]
public class StationController : BaseController<StationRepository, Station>
{
    public StationController(StationRepository repository) : base(repository) { }
}
