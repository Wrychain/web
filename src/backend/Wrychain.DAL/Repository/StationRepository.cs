using Wrychain.DAL.Entity.Stations;

namespace Wrychain.DAL.Repository;

public class StationRepository: Repository<Station>
{
    public StationRepository(ApplicationDbContext context) : base(context) { }
}
