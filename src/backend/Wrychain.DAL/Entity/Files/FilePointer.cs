using Wrychain.DAL.Enum;

namespace Wrychain.DAL.Entity.Files;

public class FilePointer: IEntity
{
    // Main
    public int Id { get; set; }
    public string? OriginalFilename { get; set; }
    public required string GeneratedFilename { get; set; }
    public required string Path { get; set; }
    public FileType FileType { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
}
