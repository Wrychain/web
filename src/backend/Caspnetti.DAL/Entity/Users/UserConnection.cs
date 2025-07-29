using Caspnetti.DAL.Enum;

namespace Caspnetti.DAL.Entity.Users;

public class UserConnection: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public int FriendId { get; set; }
    public required User Friend { get; set; }

    public UserConnection()
    {
        this.CreatedAt = DateTime.Now;
    }
}
