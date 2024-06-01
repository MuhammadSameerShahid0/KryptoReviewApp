using Dot_Net_Web_API.Data;
using Dot_Net_Web_API.Models;
using KryptoReviewApp.Interfaces;

namespace KryptoReviewApp.Repository
{
    public class CoinsRepository : ICoinsRepository
    {
        private readonly DataContext _context;

        public CoinsRepository (DataContext context)
        {
            _context = context;
        }

        public bool DeleteCoin(Coins coins)
        {
           _context.Remove(coins);
            return save();
        }

        public ICollection<Coins> GetCoins()
        {
            return _context.coins.OrderBy(c => c.CoinId).ToList();
        }

        public Coins GetCoins(int CoinId)
        {
            return _context.coins.Where(cd => cd.CoinId == CoinId).FirstOrDefault();
        }

        public Coins GetCoins(string Symbol)
        {
            return _context.coins.Where(cs => cs.Symbol == Symbol).FirstOrDefault();
        }

        public Coins GetCoins(decimal Price)
        {
            return _context.coins.Where(cp => cp.Price == Price).FirstOrDefault();
        }

        public Coins GetCoinsName(string Name)
        {
            return _context.coins.Where(cn => cn.Name == Name).FirstOrDefault();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
