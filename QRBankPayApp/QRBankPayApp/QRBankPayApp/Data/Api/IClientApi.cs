using QRBankPayApp.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QRBankPayApp.Data.Api
{
    public interface IClientApi
    {
        [Get("/Clients")]
        Task<List<Client>> GetClients();
    }
}
