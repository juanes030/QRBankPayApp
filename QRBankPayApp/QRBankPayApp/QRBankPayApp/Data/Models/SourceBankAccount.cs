namespace QRBankPayApp.Data.Models
{
    public class SourceBankAccount
    {
        public long Id { get; set; }
        public string Dna { get; set; } = string.Empty;
        public string SourceAccount { get; set; } = string.Empty;
    }
}
