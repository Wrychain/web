using Caspnetti.DAL.Entity.Invites;

namespace Caspnetti.DAL.Repository;

public class PlatformInviteRepository: Repository<PlatformInvite>
{
    public PlatformInviteRepository(ApplicationDbContext context) : base(context) { }
}
