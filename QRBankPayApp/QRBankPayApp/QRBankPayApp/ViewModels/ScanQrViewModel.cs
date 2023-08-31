using QRBankPayApp.Resx;
using QRBankPayApp.Services;
using QRBankPayApp.Views;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        private bool _isScanning;
        public bool IsScanning
        {
            get => _isScanning;
            set
            {
                if (_isScanning != value)
                {
                    _isScanning = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _scannedResult;
        public string ScannedResult
        {
            get => _scannedResult;
            set
            {
                if (_scannedResult != value)
                {
                    _scannedResult = value;
                    OnPropertyChanged();
                }
            }
        }

        private ImageSource _selectedImage;
        public ImageSource SelectedImage
        {
            get => _selectedImage;
            set
            {
                if (_selectedImage != value)
                {
                    _selectedImage = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _resultText;
        public string ResultText
        {
            get => _resultText;
            set
            {
                if (_resultText != value)
                {
                    _resultText = value;
                    OnPropertyChanged();
                }
            }
        }
        public Command lectorCommand { get; }
        public Command ScanImagenCommand { get; }        
        public Command PickImageCommand { get; }
        public ScanQrViewModel()
        {
            lectorCommand = new Command(OnLectorClicked);
            //ScanImagenCommand = new Command(ScanImage);
            PickImageCommand = new Command(PickImage);
        }

        /*private async void ScanImage()
        {
            try
            {
                if(SelectedImage != null)
                {
                    var imageStream = await GetImageStreamAsync(SelectedImage);
                    if (imageStream != null)
                    {
                        var barcodeReader = new BarcodeReader();
                        var resultado = barcodeReader.Decode(imageStream);
                        if (resultado != null)
                        {
                            ScannedResult = resultado.Text;
                        }
                        else
                        {
                            ScannedResult = "No se encontro nigun codigo QR en la imagen";
                        }
                    }            
                }
                else
                {
                    ScannedResult = "Primero seleccione una imagen de la galeria";
                }                
            }
            catch(Exception ex)
            {
                ScannedResult = "Ocurrio un error escaneando la imagen";
            }
        }*/

        private async Task<Stream> GetImageStreamAsync(ImageSource imageSource)
        {
            if(imageSource is StreamImageSource streamImageSource)
            {
                var stream = await streamImageSource.Stream(CancellationToken.None);
                var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return memoryStream;
            }
            return null;
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

        async void ScanFromGallery()
        {
            var status = await Permissions.RequestAsync<Permissions.Phone>();

            if(status == PermissionStatus.Granted)
            {
                try
                {
                    var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                    {
                        Title = "Select a Photo"
                    });

                    if(result != null)
                    {
                        using (var stream = await result.OpenReadAsync())
                        {
                            byte[] byteArray;
                            using (var memoryStream = new MemoryStream())
                            {
                                await stream.CopyToAsync(memoryStream);
                                byteArray = memoryStream.ToArray();
                            }
                            var barcodeReader = new ZXing.BarcodeReader();
                            var zxingResult = barcodeReader.Decode(byteArray);
                            if(zxingResult != null)
                            {
                                ResultText = zxingResult.Text;
                            }
                            else
                            {
                                ResultText = "No QR code found in the selected image.";
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    ResultText = "No QR code found in the selected image.";
                }
            }
            else
            {
                ResultText = "Permission to access photo denied";
            }
        }

        private async void PickImage()
        {
            try
            {
                var pickResut = await MediaPicker.PickPhotoAsync();
                if(pickResut != null)
                {
                    SelectedImage = ImageSource.FromFile(pickResut.FullPath);
                    ResultText = "Juan Alvarez";
                    ScannedResult = "9870838727";
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
