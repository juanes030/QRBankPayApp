using System.Threading.Tasks;

namespace QRBankPayApp.Services
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string userName, string password);
    }
}
