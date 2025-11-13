using Wrychain.DAL.Entity.Categories;
using Wrychain.DAL.Entity.Channels;
using Wrychain.DAL.Entity.Files;
using Wrychain.DAL.Entity.Invites;
using Wrychain.DAL.Entity.Messages;
using Wrychain.DAL.Entity.Stations;
using Wrychain.DAL.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Wrychain.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(){}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

    // Categories
    public DbSet<Category> Category { get; set; }
    public DbSet<CategoryChannel> CategoryChannel { get; set; }

    // Channels
    public DbSet<Channel> Channel { get; set; }
    public DbSet<ChannelReader> ChannelReader { get; set; }
    public DbSet<ChannelWriter> ChannelWriter { get; set; }
    public DbSet<Presence> Presence { get; set; }
    public DbSet<Progress> Progress { get; set; }

    // Files
    public DbSet<FilePointer> FilePointer { get; set; }

    // Invites
    public DbSet<ChannelInvite> ChannelInvite { get; set; }
    public DbSet<FriendInvite> FriendInvite { get; set; }
    public DbSet<PlatformInvite> PlatformInvite { get; set; }
    public DbSet<StationInvite> StationInvite { get; set; }

    // Messages
    public DbSet<Attachment> Attachment { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<Reaction> Reaction { get; set; }
    public DbSet<Receipt> Receipt { get; set; }

    // Stations
    public DbSet<Station> Station { get; set; }
    public DbSet<StationChannel> StationChannel { get; set; }
    public DbSet<StationDefaultCategory> StationDefaultCategory { get; set; }
    public DbSet<StationUserCategory> StationUserCategory { get; set; }
    public DbSet<StationUserSetting> StationUserSetting { get; set; }

    // Users
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
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Wrychain.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("MSSQLConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Preventing multiple cascade paths


        // Categories

        modelBuilder.Entity<Category>()
            .HasOne(category => category.Creator)
            .WithMany()
            .HasForeignKey(category => category.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>()
            .HasOne(category => category.Station)
            .WithMany()
            .HasForeignKey(category => category.StationId)
            .OnDelete(DeleteBehavior.Restrict);

        // Channels

        modelBuilder.Entity<Channel>()
            .HasOne(channel => channel.Creator)
            .WithMany()
            .HasForeignKey(channel => channel.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Invites

        modelBuilder.Entity<ChannelInvite>()
            .HasOne(channelInvite => channelInvite.Receiver)
            .WithMany()
            .HasForeignKey(channelInvite => channelInvite.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ChannelInvite>()
            .HasOne(channelInvite => channelInvite.Sender)
            .WithMany()
            .HasForeignKey(channelInvite => channelInvite.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FriendInvite>()
            .HasOne(friendInvite => friendInvite.Receiver)
            .WithMany()
            .HasForeignKey(friendInvite => friendInvite.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FriendInvite>()
            .HasOne(friendInvite => friendInvite.Sender)
            .WithMany()
            .HasForeignKey(friendInvite => friendInvite.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StationInvite>()
            .HasOne(stationInvite => stationInvite.Sender)
            .WithMany()
            .HasForeignKey(stationInvite => stationInvite.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Messages

        modelBuilder.Entity<Message>()
            .HasOne(message => message.Author)
            .WithMany()
            .HasForeignKey(message => message.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Message>()
            .HasMany(message => message.ParentReplies)
            .WithMany(message => message.ChildReplies);

        // Stations

        modelBuilder.Entity<Station>()
            .HasOne(station => station.Creator)
            .WithMany(user => user.CreatedStations)
            .HasForeignKey(station => station.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Station>()
            .HasMany(station => station.Members)
            .WithMany(user => user.JoinedStations);

        

        

        

        
    }
}
