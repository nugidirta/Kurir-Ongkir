using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KurirOngkir.Models;

namespace KurirOngkir.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Filter Item { get; set; }

        public string KotaAsal = "";
        public string KotaTujuan = "";
        public double Berat = 0;
        public string Kurir = "jne";

        public NewItemPage()
        {
            InitializeComponent();

            //Creating TapGestureRecognizers    
            var tapImageAsal = new TapGestureRecognizer();
            var tapImageTuju = new TapGestureRecognizer();
            var tapImageCek = new TapGestureRecognizer();
            
            //Binding events    
            tapImageAsal.Tapped += tapImageAsal_Tapped;
            tapImageTuju.Tapped += tapImageTuju_Tapped;
            tapImageCek.Tapped += tapImageCek_Tapped;

            //Associating tap events to the image buttons    
            imgAsal.GestureRecognizers.Add(tapImageAsal);
            imgTuju.GestureRecognizers.Add(tapImageTuju);
            imgCek.GestureRecognizers.Add(tapImageCek);
            



            MessagingCenter.Subscribe<KotasPage, Kota.Results>(this, "KotaAsal", (sender, arg) => {
                KotaAsal = arg.city_id;
                kotaAsal.Text = arg.city_name;

            });

            MessagingCenter.Subscribe<KotasPage, Kota.Results>(this, "KotaTuju", (sender, arg) => {
                KotaTujuan = arg.city_id;
                kotaTuju.Text = arg.city_name;
            });
                        



            BindingContext = this;
        }

        async void tapImageAsal_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new KotasPage("KotaAsal")));
            // handle the tap    
            // DisplayAlert("Alert", "This is an image button", "OK");
        }

        async void tapImageTuju_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new KotasPage("KotaTuju")));
        }

        async void tapImageCek_Tapped(object sender, EventArgs e)
        {

            Berat = Convert.ToDouble(entryBerat.Text);

            if (KotaAsal.Equals(""))
            {
                await DisplayAlert("Kota Asal", "Kota Asal belum diisi", "OK");
                return;
            }

            if (KotaTujuan.Equals(""))
            {
                await DisplayAlert("Kota Tujuan", "Kota Tujuan belum diisi", "OK");
                return;
            }

            if (Berat <= 0)
            {
                await DisplayAlert("Berat", "Berat belum diisi", "OK");
                return;
            }

            Item = new Filter
            {
                kota_asal_id = KotaAsal,
                kota_asal_nama = kotaAsal.Text,
                kota_tujuan_id = KotaTujuan,
                kota_tujuan_nama = kotaTuju.Text,
                berat = Berat,
            };
            await Navigation.PushModalAsync(new NavigationPage(new CostsPage(Item)));
        }
    }
}