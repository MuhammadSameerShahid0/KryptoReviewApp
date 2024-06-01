using Dot_Net_Web_API.Models;
using Microsoft.VisualBasic;

namespace KryptoReviewApp.Interfaces
{
    public interface IWalletRepository
    {
        ICollection<Wallet> GetWallet();
        public Wallet GetWallet  (int id); 
        public Wallet GetWallet  (string name);
        public Wallet GetWallet  (DateTime DoT);
        Task<Wallet> CreateWalletAsync (Wallet wallet);
        bool save();
        bool UpdateWallet(Wallet wallet);   
        bool DeleteWallet(int uid);
    }
}
