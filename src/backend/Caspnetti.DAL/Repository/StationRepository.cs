using Caspnetti.DAL.Entity.Stations;

namespace Caspnetti.DAL.Repository;

public class StationRepository: Repository<Station>
{
    public StationRepository(ApplicationDbContext context) : base(context) { }
}
