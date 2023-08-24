using QRBankPayApp.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QRBankPayApp.Data.Api
{
    public interface ITransactionApi
    {
        [Get("/Transaction")]
        Task<List<Transaction>> GetTransaction();
    }
}
