
using AutoMapper;
using Dot_Net_Web_API.Models;
using KryptoReviewApp.Dto;
namespace KryptoReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Users, UserDTO>();
            CreateMap<UserDTO , Users>();
            
            CreateMap<Wallet, WalletDTO>();
            CreateMap<WalletDTO  , Wallet>();

            CreateMap<Coins, CoinsDTo>();

            CreateMap<Transaction, TransactionDTo>();
            CreateMap<TransactionDTo, Transaction>();

            CreateMap<FollowedCoins, FollowedCoinsDTO>();
            CreateMap<FollowedCoins, FollowedCoinsPostDTO>();
            CreateMap<FollowedCoinsDTO, FollowedCoins>();
            CreateMap<FollowedCoinsPostDTO, FollowedCoins>();
        }
    }
}
