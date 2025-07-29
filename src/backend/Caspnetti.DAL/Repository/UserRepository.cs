using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Repository;

public class UserRepository: Repository<User>
{
    public UserRepository(ApplicationDbContext context) : base(context) { }
}
