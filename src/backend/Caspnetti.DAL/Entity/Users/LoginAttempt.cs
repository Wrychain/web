namespace Caspnetti.DAL.Entity.Users;

public class LoginAttempt: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public LoginAttempt()
    {
        this.CreatedAt = DateTime.Now;
    }
}
