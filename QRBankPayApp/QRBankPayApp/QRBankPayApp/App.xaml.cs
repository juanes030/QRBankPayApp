using QRBankPayApp.Services;
using QRBankPayApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRBankPayApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Startup.Initialize();
            MainPage = Startup.Resolve<AppShell>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
