using Dot_Net_Web_API.Models;

namespace KryptoReviewApp.Dto
{
    public class FollowedCoinsDTO
    {
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int CoinId { get; set; }
        public CoinsDTo Coin { get; set; }
    }

    public class FollowedCoinsPostDTO
    {
        public int UserId { get; set; }
        public int CoinId { get; set; }
    }
}
