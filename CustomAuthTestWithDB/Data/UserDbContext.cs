using CustomAuthTestWithDB.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomAuthTestWithDB.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var userAccounts = new UserAccount[]
        {
            new UserAccount()
            {
                Id = 1,
                UserName = "weather",
                Password = "weather",
            },
            new UserAccount()
            {
                Id = 2,
                UserName = "counter",
                Password = "counter",
            },
            new UserAccount()
            {
                Id = 3,
                UserName = "god",
                Password = "god"
            }
        };
        
        modelBuilder.Entity<UserAccount>().HasData(userAccounts);

        var userAccountPolicies = new UserAccountPolicy[]
        {
            new UserAccountPolicy()
                { Id = 1, UserAccountId = 1, UserPolicy = UserPolicy.VIEW_WEATHER, IsEnabled = true },
            new UserAccountPolicy()
                { Id = 2, UserAccountId = 1, UserPolicy = UserPolicy.VIEW_COUNTER, IsEnabled = false },

            new UserAccountPolicy()
                { Id = 3, UserAccountId = 2, UserPolicy = UserPolicy.VIEW_WEATHER, IsEnabled = false },
            new UserAccountPolicy()
                { Id = 4, UserAccountId = 2, UserPolicy = UserPolicy.VIEW_COUNTER, IsEnabled = true },

            new UserAccountPolicy()
                { Id = 5, UserAccountId = 3, UserPolicy = UserPolicy.VIEW_WEATHER, IsEnabled = true },
            new UserAccountPolicy()
                { Id = 6, UserAccountId = 3, UserPolicy = UserPolicy.VIEW_COUNTER, IsEnabled = true },
        };
        
        modelBuilder.Entity<UserAccountPolicy>().HasData(userAccountPolicies);
    }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<UserAccountPolicy> UserAccountPolicies { get; set; }
}