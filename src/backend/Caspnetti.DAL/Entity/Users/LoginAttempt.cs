namespace Caspnetti.DAL.Entity.Users;

public class LoginAttempt: IEntity
{
    // Main
    public int Id { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
