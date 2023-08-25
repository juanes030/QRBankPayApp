using QRBankPayApp.Resx;
using QRBankPayApp.Services;
using QRBankPayApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing;

namespace QRBankPayApp.ViewModels
{
    public class ScanQrViewModel : BaseViewModel
    {
        private string _entryQr;
        public string EntryQr
        {
            get => _entryQr;
            set
            {
                if (_entryQr != value)
                {
                    _entryQr = value;
                    OnPropertyChanged();
                }
            }
        }
        public Command lectorCommand { get; }
        public ScanQrViewModel()
        {
            lectorCommand = new Command(OnLectorClicked);
        }

        private async void OnLectorClicked()
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "Escanear codigo qr";
                scanner.BottomText = "QRBankPlay";
                var result = await scanner.Scan();
                if(result != null)
                {
                    EntryQr = result.Text;
                }
            }
            catch (Exception ex) 
            {
                
            }
        }
    }
}
