using Dot_Net_Web_API.Models;

namespace KryptoReviewApp.Interfaces
{
    public interface ITransactionRepository
    {
        ICollection<Transaction> GetTransaction();

        public Transaction GetTransaction  (int TransactionId);
        public Transaction GetTransaction  (decimal Quantity);
        public Transaction GetTransaction  (DateTime TransactionDate);
        Task<Transaction> PostTransactionAsync (Transaction transaction);
    }
}
