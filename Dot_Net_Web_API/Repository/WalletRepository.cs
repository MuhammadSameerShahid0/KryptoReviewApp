using Dot_Net_Web_API.Data;
using Dot_Net_Web_API.Models;
using KryptoReviewApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace KryptoReviewApp.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DataContext _context;

        public WalletRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Wallet> CreateWalletAsync(Wallet wallet)
        {
            _context.wallets.Add(wallet);
            await _context.SaveChangesAsync();
            return wallet;

        }
        public ICollection<Wallet> GetWallet()
        {
            return _context.wallets.OrderBy(u => u.WalletID).ToList();
        }
        public Wallet GetWallet(int id)
        {
            return _context.wallets.Where(u => u.WalletID == id).FirstOrDefault();
        }
        public Wallet GetWallet(string name)
        {
            return _context.wallets.Where(wn => wn.WalletName == name).FirstOrDefault();
        }
        public Wallet GetWallet(DateTime DoT)
        {
            return _context.wallets.Where(wn => wn.CreatedAt == DoT).FirstOrDefault();
        }
        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool UpdateWallet(Wallet wallet)
        {
            _context.wallets.Update(wallet);
            return save();
        }
        public bool DeleteWallet(int uid)
        {
            Wallet wallet = _context.wallets.FirstOrDefault(w => w.UserID == uid);
            if (wallet != null)
            {
                _context.wallets.Remove(wallet);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
