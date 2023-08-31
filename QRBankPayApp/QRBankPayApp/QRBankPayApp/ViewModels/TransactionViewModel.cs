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

        private string _cuentaOrigen;
        public string CuentaOrigen
        {
            get => _cuentaOrigen;
            set
            {
                if (_cuentaOrigen != value)
                {
                    _cuentaOrigen = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _documento;
        public string Documento
        {
            get => _documento;
            set
            {
                if (_documento != value)
                {
                    _documento = value;
                    OnPropertyChanged();
                }
            }
        }

        public TransactionViewModel(ITransactionService transactionService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            ScanQrCommand = new AsyncCommand(async () => await OnScanQrAsync());
            GenerateQrCommand = new AsyncCommand(async () => await OnGenerateQrAsync(Documento));
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
                    Transaction item = transactions[0];
                    Documento = item.CuentaOrigen;
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

        private async Task OnGenerateQrAsync(string documento)
        {
            //await Shell.Current.GoToAsync($"//{nameof(GenerateQrPage)}");
            await Shell.Current.GoToAsync($"{nameof(GenerateQrPage)}?{nameof(GenerateQrViewModel.Documento)}={documento}");
        }
    }
}
