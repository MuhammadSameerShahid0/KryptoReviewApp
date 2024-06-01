using Microsoft.EntityFrameworkCore;
using Dot_Net_Web_API.Models;

namespace Dot_Net_Web_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Users> users                 { get; set; }
        public DbSet<Wallet> wallets              { get; set; }
        public DbSet<Coins> coins                 { get; set; }
        public DbSet<Transaction> transactions    { get; set; }
        public DbSet<FollowedCoins> FollowedCoins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User-Wallet relationship
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wallets)
                .HasForeignKey(w => w.UserID);        

            // Coin-Transaction relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Coin)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CoinId);

            // User-Coin many-to-many relationship
            modelBuilder.Entity<FollowedCoins>()
                .HasKey(fc => new { fc.UserId, fc.CoinId });

            modelBuilder.Entity<FollowedCoins>()
                .HasOne(fc => fc.User)
                .WithMany(u => u.FollowedCoins)
                .HasForeignKey(fc => fc.UserId);

            modelBuilder.Entity<FollowedCoins>()
                .HasOne(fc => fc.Coin)
                .WithMany(c => c.FollowedCoins)
                .HasForeignKey(fc => fc.CoinId);
        }
    }
}
