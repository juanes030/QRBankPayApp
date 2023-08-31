using QRBankPayApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QRBankPayApp.Services
{
    public interface ISourceBankAccountsService
    {
        Task<SourceBankAccount> GetSourceBankAccounts(string Documento);
    }
}
