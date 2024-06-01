using Dot_Net_Web_API.Models;

namespace KryptoReviewApp.Interfaces
{
    public interface IFollowedCoins
    {
        Task<IEnumerable<FollowedCoins>> GetAllFollowedCoinsAsync();
        Task<FollowedCoins> FollowedUCId (int userId, int coinId);
        Task<FollowedCoins> CreatefollowedAsync(FollowedCoins followedCoins);
    }
}
