using QRBankPayApp.Data.Api;
using QRBankPayApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRBankPayApp.Services
{
    internal class SourceBankAccountsService : ISourceBankAccountsService
    {
        private readonly ISourceBankAccountsApi _sourceBankAccountsApi;

        public SourceBankAccountsService(ISourceBankAccountsApi sourceBankAccounts)
        {
            _sourceBankAccountsApi = sourceBankAccounts;
        }

        public async Task<SourceBankAccount> GetSourceBankAccounts(string Documento)
        {
            var sourceBankAccounts = new SourceBankAccount();

            try
            {
                sourceBankAccounts = await _sourceBankAccountsApi.GetSourceBankAccounts(Documento);
                return sourceBankAccounts;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return sourceBankAccounts;
        }
    }
}
