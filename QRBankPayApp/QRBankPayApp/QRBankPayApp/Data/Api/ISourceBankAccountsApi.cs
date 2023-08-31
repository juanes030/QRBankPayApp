using QRBankPayApp.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QRBankPayApp.Data.Api
{
    public interface ISourceBankAccountsApi
    {
        [Get("/SourceBankAccounts/{Documento}")]
        Task<SourceBankAccount> GetSourceBankAccounts(string Documento);
    }
}
