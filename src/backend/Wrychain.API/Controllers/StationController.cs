using Wrychain.DAL.Entity.Stations;
using Wrychain.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Wrychain.API.Controllers;

[ApiController]
[Route("api/station")]
public class StationController : BaseController<StationRepository, Station>
{
    public StationController(StationRepository repository) : base(repository) { }
}
