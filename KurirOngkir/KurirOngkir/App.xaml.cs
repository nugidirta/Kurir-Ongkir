using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KurirOngkir.Views;
using System.Globalization;
using System.Threading;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KurirOngkir
{
    public partial class App : Application
    {
        /**
        * Kurir Ongkir App
        *
        * @package  Xamarin Kurir Ongkir
        * @author   Ketut Ugi Diranta <nugi.dirta@gmail.com>
        */
        public App()
        {
            InitializeComponent();

            //CultureInfo.CurrentUICulture = new CultureInfo("en-US");
            //var cul = CultureInfo.CurrentUICulture;
            //Thread.CurrentThread.CurrentCulture = cul;
            //Thread.CurrentThread.CurrentUICulture = cul;
            //CultureInfo.DefaultThreadCurrentCulture = cul;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
