using Dot_Net_Web_API.Models;

namespace KryptoReviewApp.Interfaces
{
    public interface ICoinsRepository
    {
        ICollection<Coins> GetCoins();

        public Coins GetCoins     (int CoinId);
        public Coins GetCoins     (string Symbol);
        public Coins GetCoinsName (string Name);
        public Coins GetCoins     (decimal Price);
        bool save();
        bool DeleteCoin (Coins coins);
    }
}
