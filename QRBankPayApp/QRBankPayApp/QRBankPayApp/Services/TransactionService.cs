using QRBankPayApp.Data.Api;
using QRBankPayApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRBankPayApp.Services
{
    internal class TransactionService : ITransactionService
    {
        private readonly ITransactionApi _transactionApi;

        public TransactionService(ITransactionApi transactionApi)
        {
            _transactionApi = transactionApi;
        }
        public async Task<List<Transaction>> GetTransaction()
        {
            var transactions = new List<Transaction>();

            try
            {
                var response = await _transactionApi.GetTransaction();
                transactions = response.ToList();
                return transactions;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return transactions;
        }
    }
}
