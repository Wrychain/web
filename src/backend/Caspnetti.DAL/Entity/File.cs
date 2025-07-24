using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using Caspnetti.DAL.Enum;

namespace Caspnetti.DAL.Entity;

[Table("Files")]
[Index(nameof(GeneratedFilename), IsUnique = true)]
[Index(nameof(Path), IsUnique = true)]
public class File: IEntity
{
    public int Id { get; set; }
    public string? OriginalFilename { get; set; }
    public required string GeneratedFilename { get; set; }
    public required string Path { get; set; }
    public FileType FileType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public File()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
