using Dot_Net_Web_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace KryptoReviewApp.Dto
{
    public class TransactionDTo
    {
        public int TransactionId        { get; set; }
        public decimal Quantity         { get; set; }
        public DateTime TransactionDate { get; set; }
        public int WalletId             { get; set; }
        public int CoinId               { get; set; }
    }
}
