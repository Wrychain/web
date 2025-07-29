using Caspnetti.DAL.Enum;

namespace Caspnetti.DAL.Entity.Files;

public class FilePointer: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string? OriginalFilename { get; set; }

    public required string GeneratedFilename { get; set; }
    public FileType FileType { get; set; }
    public required string Path { get; set; }

    public FilePointer()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
