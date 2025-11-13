using Wrychain.DAL.Entity.Categories;
using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Stations;

// StationUserCategory is created after Category to link via Station::UserCategories
public class StationUserCategory: IEntity
{
    // Main
    public int Id { get; set; }
    public required int SortIndex { get; set; }
    public required int UserId { get; set; }
    public required int StationId { get; set; }
    public required int CategoryId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? User { get; set; }
    public Station? Station { get; set; }
    public Category? Category { get; set; }
}
