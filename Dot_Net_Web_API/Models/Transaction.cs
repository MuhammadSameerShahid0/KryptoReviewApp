using System.ComponentModel.DataAnnotations.Schema;

namespace Dot_Net_Web_API.Models
{
    public class Transaction
    {
        public int TransactionId                 { get; set; }
        public decimal Quantity                  { get; set; }
        public DateTime TransactionDate          { get; set; }

        public Wallet Wallet                     { get; set; }
        public Coins Coin                        { get; set; }

        // Foreign keys
        public int WalletId                      { get; set; }
        public int CoinId                        { get; set; }

    }
}
