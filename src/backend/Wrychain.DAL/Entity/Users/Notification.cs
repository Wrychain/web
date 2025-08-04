using Wrychain.DAL.Entity.Files;

namespace Wrychain.DAL.Entity.Users;

public class Notification: IEntity
{
    // Main
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
    public int? IconId { get; set; }
    public int? BadgeId { get; set; }
    public int? ImageId { get; set; }
    public string? Data { get; set; }
    public string? Tag { get; set; }
    public bool? Renotify { get; set; }
    public bool? RequireInteraction { get; set; }
    public bool? Silent { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? ReadAt { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation
    public FilePointer? Icon { get; set; }
    public FilePointer? Badge { get; set; }
    public FilePointer? Image { get; set; }
    public List<FilePointer>? ActionIcons { get; set; }
}
