using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Repository;

public class UserRepository: Repository<User>
{
    public UserRepository(ApplicationDbContext context) : base(context) { }
}
