namespace Project.Infrastructure.DTOs.Account
{
    public class TransferDto
    {
        public string AccountSender { get; set; }
        public string AccountReceiver { get; set; }
        public decimal Amount { get; set; }
    }
}
