using Caspnetti.DAL.Entity.Channels;
using Caspnetti.DAL.Entity.Feeds;
using Caspnetti.DAL.Entity.Files;
using Caspnetti.DAL.Entity.Invites;
using Caspnetti.DAL.Entity.Messages;
using Caspnetti.DAL.Entity.Stations;
using Caspnetti.DAL.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Caspnetti.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(){}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

    public DbSet<Channel> Channel { get; set; }
    public DbSet<ChannelFeed> ChannelFeed { get; set; }

    public DbSet<Feed> Feed { get; set; }
    public DbSet<FeedReader> FeedReader { get; set; }
    public DbSet<FeedWriter> FeedWriter { get; set; }
    public DbSet<Presence> Presence { get; set; }
    public DbSet<Progress> Progress { get; set; }

    public DbSet<FilePointer> FilePointer { get; set; }

    public DbSet<FeedInvite> FeedInvite { get; set; }
    public DbSet<FriendInvite> FriendInvite { get; set; }
    public DbSet<PlatformInvite> PlatformInvite { get; set; }
    public DbSet<StationInvite> StationInvite { get; set; }

    public DbSet<Attachment> Attachment { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<Reaction> Reaction { get; set; }
    public DbSet<Receipt> Receipt { get; set; }

    public DbSet<Station> Station { get; set; }
    public DbSet<StationCustomChannel> StationCustomChannel { get; set; }
    public DbSet<StationDefaultChannel> StationDefaultChannel { get; set; }
    public DbSet<StationFeed> StationFeed { get; set; }
    public DbSet<StationUserSetting> StationUserSetting { get; set; }

    public DbSet<LoginAttempt> LoginAttempt { get; set; }
    public DbSet<LoginSession> LoginSession { get; set; }
    public DbSet<Notification> Notification { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserConnection> UserConnection { get; set; }
    public DbSet<UserVAPID> UserVAPID { get; set; }

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Preventing multiple cascade paths

        modelBuilder.Entity<Channel>()
            .HasOne(channel => channel.Station)
            .WithMany()
            .HasForeignKey(channel => channel.StationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Feed>()
            .HasOne(feed => feed.Creator)
            .WithMany()
            .HasForeignKey(feed => feed.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FriendInvite>()
            .HasOne(friendInvite => friendInvite.Sender)
            .WithMany()
            .HasForeignKey(friendInvite => friendInvite.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FriendInvite>()
            .HasOne(friendInvite => friendInvite.Receiver)
            .WithMany()
            .HasForeignKey(friendInvite => friendInvite.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Station>()
            .HasOne(station => station.Creator)
            .WithMany(user => user.CreatedStations)
            .HasForeignKey(station => station.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Station>()
            .HasMany(station => station.Members)
            .WithMany(user => user.JoinedStations);

        modelBuilder.Entity<FeedInvite>()
            .HasOne(feedInvite => feedInvite.Sender)
            .WithMany()
            .HasForeignKey(feedInvite => feedInvite.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FeedInvite>()
            .HasOne(feedInvite => feedInvite.Receiver)
            .WithMany()
            .HasForeignKey(feedInvite => feedInvite.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Message>()
            .HasOne(message => message.Author)
            .WithMany()
            .HasForeignKey(message => message.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<StationInvite>()
            .HasOne(stationInvite => stationInvite.Sender)
            .WithMany()
            .HasForeignKey(stationInvite => stationInvite.SenderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Channel>()
            .HasOne(channel => channel.Creator)
            .WithMany()
            .HasForeignKey(channel => channel.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
