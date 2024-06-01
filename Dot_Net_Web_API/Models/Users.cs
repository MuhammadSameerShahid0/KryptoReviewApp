using System.ComponentModel.DataAnnotations;

namespace Dot_Net_Web_API.Models
{
    public class Users
    {
        [Key]
        public int UserID                  { get; set; }
        public string UserName             { get; set; }
        public string Email                { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
        // Many-to-many relationship
        public List<FollowedCoins> FollowedCoins { get; set; } 
    }
}
