using Dot_Net_Web_API.Data;
using Dot_Net_Web_API.Models;
using KryptoReviewApp.Interfaces;

namespace KryptoReviewApp.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Transaction> GetTransaction()
        {
           return _context.transactions.OrderBy(tl => tl.TransactionId).ToList();
        }

        public Transaction GetTransaction(int TransactionId)
        {
            return _context.transactions.Where(trnd => trnd.TransactionId == TransactionId).FirstOrDefault();
        }

        public Transaction GetTransaction(decimal Quantity)
        {
            return _context.transactions.Where(qu => qu.Quantity == Quantity).FirstOrDefault();
        }

        public Transaction GetTransaction(DateTime TransactionDate)
        {
            return _context.transactions.Where(dot => dot.TransactionDate == TransactionDate).FirstOrDefault();
        }

        public async Task<Transaction> PostTransactionAsync(Transaction transaction)
        {
            _context.transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
