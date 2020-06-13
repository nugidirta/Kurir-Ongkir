using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KurirOngkir.ViewModels;
using KurirOngkir.Models;

namespace KurirOngkir.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KotasPage : ContentPage
	{
        KotasViewModel viewModel;
        string OpsiPage = "KotaAsal";
        

        public KotasPage(string opsi)
        {
            InitializeComponent();
            OpsiPage = opsi;
            this.searchBar.IsVisible = false;
            BindingContext = viewModel = new KotasViewModel();
            ItemsListView.ItemsSource = viewModel.Kotas;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Kota.Results;
            if (item == null)
                return;

            MessagingCenter.Send(this, OpsiPage, item);
            await Navigation.PopModalAsync();


            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Kotas.Count == 0)
                viewModel.LoadKotasCommand.Execute(null);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ItemsListView.ItemsSource = viewModel.Kotas;
            }
            else
            {
                ItemsListView.ItemsSource = viewModel.Kotas.Where(
                    x => x.city_name.ToLower().StartsWith(e.NewTextValue.ToLower()) || x.city_id.ToLower().StartsWith(e.NewTextValue.ToLower())
                );
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (this.searchBar.IsVisible == false)
            {
                this.searchBar.IsVisible = true;
            }
            else
            {
                this.searchBar.IsVisible = false;
            }
        }
    }
}