using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace KurirOngkir.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Tentang";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://twitter.com/nugidirta")));
        }

        public ICommand OpenWebCommand { get; }
    }
}