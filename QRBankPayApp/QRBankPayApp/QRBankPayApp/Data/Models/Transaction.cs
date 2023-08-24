namespace QRBankPayApp.Data.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
