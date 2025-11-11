using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Repository;

public class LoginSessionRepository: Repository<LoginSession>
{
    public LoginSessionRepository(ApplicationDbContext context) : base(context) { }
}
