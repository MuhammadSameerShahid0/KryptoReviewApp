using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Dot_Net_Web_API.Models
{
    public class Coins
    {
        [Key]
        public int CoinId                            { get; set; } // Primary Key
        public string Symbol                         { get; set; }
        public string Name                           { get; set; }
        public decimal Price                         { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        // Many-to-many relationship
        public List<FollowedCoins> FollowedCoins { get; set; }
    }
}
