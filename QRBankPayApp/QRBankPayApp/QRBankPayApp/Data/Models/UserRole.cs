using QRBankPayApp.Enumerations;

namespace QRBankPayApp.Data.Models
{
    public class UserRole
    {
        public long RoleId { get; set; }
        public string Name { get; set; }
        public RoleType Type { get; set; }
    }
}
