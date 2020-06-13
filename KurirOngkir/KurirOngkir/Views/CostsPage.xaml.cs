using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KurirOngkir.ViewModels;
using KurirOngkir.Models;
using KurirOngkir.Services;
using KurirOngkir.Ads;

namespace KurirOngkir.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CostsPage : ContentPage
	{
        CostsViewModel viewModel;

        public CostsPage(Filter Item)
        {
            InitializeComponent();

            ////Creating TapGestureRecognizers    
            //var tapbutton = new TapGestureRecognizer();
            ////Binding events    
            //tapbutton.Tapped += tapbutton_Tapped;
            ////Associating tap events to the image buttons    
            //floatButton.GestureRecognizers.Add(tapbutton);

            BindingContext = viewModel = new CostsViewModel(Item, new DialogService());
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ListOfCost.Count == 0)
                viewModel.LoadCostsCommand.Execute(null);
        }
    }
}