using Caspnetti.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Caspnetti.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(){}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

    public DbSet<Chain> Chains { get; set; }
    public DbSet<FilePointer> FilePointers { get; set; }
    public DbSet<Mesh> Meshes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageAttachment> MessageAttachments { get; set; }
    public DbSet<MessageReaction> MessageReactions { get; set; }
    public DbSet<MessageReceipt> MessageReceipts { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Caspnetti.DAL.Entity.Thread> Threads { get; set; }
    public DbSet<ThreadOrdering> ThreadOrderings { get; set; }
    public DbSet<ThreadPresence> ThreadPresences { get; set; }
    public DbSet<ThreadProgress> ThreadProgresses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Build configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Caspnetti.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("MSSQLConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
