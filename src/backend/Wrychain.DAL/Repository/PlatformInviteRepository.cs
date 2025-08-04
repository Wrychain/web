using Wrychain.DAL.Entity.Invites;

namespace Wrychain.DAL.Repository;

public class PlatformInviteRepository: Repository<PlatformInvite>
{
    public PlatformInviteRepository(ApplicationDbContext context) : base(context) { }
}
