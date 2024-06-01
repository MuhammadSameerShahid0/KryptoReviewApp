namespace Dot_Net_Web_API.Models
{
    public class Wallet
    {
        public int WalletID         { get; set; }
        public string WalletName    { get; set; }
        public DateTime CreatedAt   { get; set; }

        // Foreign key
        public int UserID           { get; set; }
        public Users User           { get; set; }
    }
}
