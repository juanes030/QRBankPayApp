using QRBankPayApp.Data.Models;
using QRBankPayApp.Services;
using QRBankPayApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace QRBankPayApp.ViewModels
{
    public class TransactionViewModel : BaseViewModel
    {
        private readonly ITransactionService _transactionService;

        public TransactionViewModel(ITransactionService transactionService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            ScanQrCommand = new AsyncCommand(async () => await OnScanQrAsync());
            GenerateQrCommand = new AsyncCommand(async () => await OnGenerateQrAsync());
            Title = "Clients";
            _transactionService = transactionService;
        }



        public ObservableRangeCollection<Transaction> Transactions { get; set; } = new ObservableRangeCollection<Transaction>();

        public ICommand AppearingCommand { get; set; }
        public ICommand ScanQrCommand { get; set; }
        public ICommand GenerateQrCommand { get; set; }

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var transactions = await _transactionService.GetTransaction();
                if (transactions != null)
                {
                    Transactions.ReplaceRange(transactions);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task OnScanQrAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(ScanQrPage)}");
        }

        private async Task OnGenerateQrAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(GenerateQrPage)}");
        }
    }
}
