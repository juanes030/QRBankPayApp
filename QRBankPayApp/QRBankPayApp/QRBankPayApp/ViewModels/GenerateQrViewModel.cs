using System.Threading.Tasks;
using System;
using System.Windows.Input;
using QRBankPayApp.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using QRBankPayApp.Data.Models;
using Xamarin.Forms;

namespace QRBankPayApp.ViewModels
{
    [QueryProperty(nameof(Documento), nameof(Documento))]
    public class GenerateQrViewModel : BaseViewModel
    {
        private readonly ISourceBankAccountsService _sourceBankAccounts;

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

        private string _documentoCliente;
        public string DocumentoCliente
        {
            get => _documentoCliente;
            set
            {
                if (_documentoCliente != value)
                {
                    _documentoCliente = value;
                    OnPropertyChanged();
                }
            }
        }

        private SourceBankAccount _cuentaOrigen;
        public SourceBankAccount CuentaOrigen
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

        private string _cuentaBancoOrigen;
        public string CuentaBancoOrigen
        {
            get => _cuentaBancoOrigen;
            set
            {
                if (_cuentaBancoOrigen != value)
                {
                    _cuentaBancoOrigen = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableRangeCollection<SourceBankAccount> SourceBankAccounts { get; set; } = new ObservableRangeCollection<SourceBankAccount>();

        public ICommand AppearingCommand { get; set; }
        public GenerateQrViewModel(ISourceBankAccountsService sourceBankAccounts)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            _sourceBankAccounts = sourceBankAccounts;
        }

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                CuentaOrigen = await _sourceBankAccounts.GetSourceBankAccounts("123");
                DocumentoCliente = CuentaOrigen.Dna;
                CuentaBancoOrigen = CuentaOrigen.SourceAccount;

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
    }
}
