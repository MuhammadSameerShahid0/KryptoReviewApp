namespace KryptoReviewApp.Dto
{
    public class WalletDTO
    {
        public int WalletID { get; set; }
        public string WalletName { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserID { get; set; }
    }
}
