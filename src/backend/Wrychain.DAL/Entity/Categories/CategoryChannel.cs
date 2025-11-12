using Wrychain.DAL.Entity.Categories;
using Wrychain.DAL.Entity.Channels;

namespace Wrychain.DAL.Entity.Categories;

// One to one join between Category and Channel w/ SortIndex
public class CategoryChannel: IEntity
{
    // Main
    public int Id { get; set; }
    public required int SortIndex { get; set; }
    public required int CategoryId { get; set; }
    public required int ChannelId { get; set; }

    // Navigation
    public Category? Category { get; set; }
    public Channel? Channel { get; set; }
}
