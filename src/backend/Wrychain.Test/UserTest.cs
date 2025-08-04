using Wrychain.DAL;
using Wrychain.DAL.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace Wrychain.Test;

public class UserTest
{
    private readonly ApplicationDbContext _context;

    public UserTest()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        this._context = new ApplicationDbContext(options);
    }

    [Fact]
    public void SuccessfulUserAdd()
    {
        User testUser = new User
        {
            Username = "BottomText",
            PasswordHash = "weeeeeeeeee",
            DisplayName = "BT",
            Email = "test@test.com"
        };

        _context.Add(testUser);
        _context.SaveChanges();

        User? returnedUser = _context.User.FirstOrDefault(user =>
            user.Username == testUser.Username &&
            user.PasswordHash == testUser.PasswordHash &&
            user.DisplayName == testUser.DisplayName &&
            user.Email == testUser.Email
        );

        Assert.True(returnedUser == testUser);
    }

    [Fact]
    public void UserFailingUsername()
    {
        User successfulUser = new User
        {
            Username = "BottomText",
            PasswordHash = "weeeeeeeeee",
            DisplayName = "BT",
            Email = "test@test.com"
        };

        User failingUsername = successfulUser;
        failingUsername.Username = null!;
        _context.Add(failingUsername);
        Assert.Throws<DbUpdateException>(() => _context.SaveChanges());
    }

    [Fact]
    public void UserFailingPasswordHash()
    {
        User successfulUser = new User
        {
            Username = "BottomText",
            PasswordHash = "weeeeeeeeee",
            DisplayName = "BT",
            Email = "test@test.com"
        };

        User failingPasswordHash = successfulUser;
        failingPasswordHash.PasswordHash = null!;
        _context.Add(failingPasswordHash);
        Assert.Throws<DbUpdateException>(() => _context.SaveChanges());
    }

    [Fact]
    public void UserFailingDisplayName()
    {
        User successfulUser = new User
        {
            Username = "BottomText",
            PasswordHash = "weeeeeeeeee",
            DisplayName = "BT",
            Email = "test@test.com"
        };

        User failingDisplayName = successfulUser;
        failingDisplayName.DisplayName = null!;
        _context.Add(failingDisplayName);
        Assert.Throws<DbUpdateException>(() => _context.SaveChanges());
    }
}
