using Caspnetti.DAL.Entity.Files;

namespace Caspnetti.DAL.Entity.Users;

public class Notification: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ReadAt { get; set; }

    public required string Title { get; set; }
    public required string Body { get; set; }

    public int? IconId { get; set; }
    public FilePointer? Icon { get; set; }
    public int? BadgeId { get; set; }
    public FilePointer? Badge { get; set; }
    public int? ImageId { get; set; }
    public FilePointer? Image { get; set; }

    public List<FilePointer>? ActionIcons { get; set; }

    public string? Data { get; set; }
    public string? Tag { get; set; }
    public bool? Renotify { get; set; }
    public bool? RequireInteraction { get; set; }
    public bool? Silent { get; set; }

    public Notification()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
    }
}
