namespace Dot_Net_Web_API.Models
{
    public class FollowedCoins
    {
        public int UserId { get; set; }
        public Users User { get; set; }

        public int CoinId { get; set; }
        public Coins Coin { get; set; }
    }
}
