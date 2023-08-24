using QRBankPayApp.Views;
using System;
using Xamarin.Forms;

namespace QRBankPayApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ScanQrPage), typeof(ScanQrPage));
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }
}
