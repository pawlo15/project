namespace Project.Infrastructure.DTOs.Account
{
    public class GetAccountDto
    {
        public string AccountNumber { get; set; }
        public short IsActive { get; set; }
        public decimal Balance { get; set; }
        public short HasDebit { get; set; }
        public decimal DebitBalance { get; set; }
    }
}
