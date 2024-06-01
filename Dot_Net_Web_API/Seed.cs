using Dot_Net_Web_API.Data;
using Dot_Net_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dot_Net_Web_API
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.users.Any())
            {
                // Seed users
                var users = new List<Users>
                {
                    new Users { UserName = "user1", Email = "user1@example.com" },
                    new Users { UserName = "user2", Email = "user2@example.com" },
                };
                dataContext.users.AddRange(users);
                dataContext.SaveChanges();
            }

                if (!dataContext.coins.Any())
                {
                    // Seed coins
                        var coins = new List<Coins>
                    {
                        new Coins { Symbol = "BTC", Name = "Bitcoin", Price = 45000 },
                        new Coins { Symbol = "ETH", Name = "Ethereum", Price = 3000 },
                        new Coins { Symbol = "XRP", Name = "Ripple", Price = 1.5m }
                    };
                    dataContext.coins.AddRange(coins);
                    dataContext.SaveChanges();
                }

            if (!dataContext.wallets.Any())
            {
                // Seed wallets
                    var wallets = new List<Wallet>
                {
                    new Wallet { WalletName = "user1's BTC Wallet", CreatedAt = DateTime.Now, UserID = dataContext.users.First(u => u.UserName == "user1").UserID },
                    new Wallet { WalletName = "user2's ETH Wallet", CreatedAt = DateTime.Now, UserID = dataContext.users.First(u => u.UserName == "user2").UserID }
                };
                    dataContext.wallets.AddRange(wallets);
                    dataContext.SaveChanges();
            }

                if (!dataContext.transactions.Any())
                {
                    // Seed transactions
                    var transactions = new List<Transaction>
                    {
                        new Transaction { Quantity = 1.0m, TransactionDate = DateTime.Now, WalletId = dataContext.wallets.First(w => w.WalletName == "user1's BTC Wallet").WalletID, CoinId = dataContext.coins.First(c => c.Symbol == "BTC").CoinId },
                        new Transaction { Quantity = 10.0m,TransactionDate = DateTime.Now, WalletId = dataContext.wallets.First(w => w.WalletName == "user2's ETH Wallet").WalletID, CoinId = dataContext.coins.First(c => c.Symbol == "ETH").CoinId }
                    };
                        dataContext.transactions.AddRange(transactions);
                        dataContext.SaveChanges();
                }

           if (!dataContext.FollowedCoins.Any())
           {
               // Seed followed coins (many-to-many relationship)
                   var followedCoins = new List<FollowedCoins>
               {
                   new FollowedCoins { UserId = dataContext.users.First(u => u.UserName == "user1").UserID, CoinId = dataContext.coins.First(c => c.Symbol == "BTC").CoinId },
                   new FollowedCoins { UserId = dataContext.users.First(u => u.UserName == "user1").UserID, CoinId = dataContext.coins.First(c => c.Symbol == "ETH").CoinId },
                   new FollowedCoins { UserId = dataContext.users.First(u => u.UserName == "user2").UserID, CoinId = dataContext.coins.First(c => c.Symbol == "ETH").CoinId },
                   new FollowedCoins { UserId = dataContext.users.First(u => u.UserName == "user2").UserID, CoinId = dataContext.coins.First(c => c.Symbol == "XRP").CoinId }
               };
                   dataContext.FollowedCoins.AddRange(followedCoins);
                   dataContext.SaveChanges();
           }
        }
    }
}