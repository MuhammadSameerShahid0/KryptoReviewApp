using Dot_Net_Web_API.Data;
using Dot_Net_Web_API.Models;
using KryptoReviewApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KryptoReviewApp.Repository
{
    public class FollowedCoinsRepository : IFollowedCoins
    {
        private readonly DataContext _context;
        public FollowedCoinsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FollowedCoins>> GetAllFollowedCoinsAsync()
        {

            return await _context.FollowedCoins
                    .Include( fc => fc.User)
                    .Include(fc => fc.Coin)
                     .ToListAsync();
          
        }
        public async Task<FollowedCoins> FollowedUCId(int userId, int coinId)
        {
            return await _context.FollowedCoins
                                 .Include(fc => fc.User)
                                 .Include(fc => fc.Coin)
                                 .FirstOrDefaultAsync(fc => fc.UserId == userId && fc.CoinId == coinId);
        }

        public async Task<FollowedCoins> CreatefollowedAsync(FollowedCoins followedCoins)
        {
            _context.FollowedCoins.Add(followedCoins);
            await _context.SaveChangesAsync();
            return followedCoins;
        }
    }
}
