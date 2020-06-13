using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using KurirOngkir.Models;
using KurirOngkir.Views;
using System.Collections.Generic;
using KurirOngkir.Services;
using System.Windows.Input;
using KurirOngkir.Ads;

namespace KurirOngkir.ViewModels
{
    public class CostsViewModel : BaseViewModel
    {

        //private readonly IDialogService _dialogService;
        public ICommand AddCommand { get; private set; }

        public Command LoadCostsCommand { get; set; }
        MockDataCost DSCost = new MockDataCost();

        public class DataCost
        {
            public string code { get; set; }
            public string name { get; set; }
            public List<Costs> costs { get; set; }

            public class Costs
            {
                public string service { get; set; }
                public string description { get; set; }                
                public double tarif { get; set; }
                public string keterangan { get; set; }          
             
            }

        }

        public class DataCostList : List<DataCost.Costs>
        {
            public string Heading { get; set; }
            public List<DataCost.Costs> DataCosts => this;
        }


        //public ObservableCollection<DataCost> Costs { get; set; }
        //public ObservableCollection<DetailCost> Costs { get; set; }
        private List<DataCostList> _listOfCost;
        public List<DataCostList> ListOfCost { get { return _listOfCost; } set { _listOfCost = value; base.OnPropertyChanged(); } }
        

        public string KotaAsal { get; set; }
        public string KotaTuju { get; set; }
        public double Berat { get; set; }

        public string Ket { get; set; }

        public CostsViewModel(Filter Item, IDialogService dialogService)
        {
            //_dialogService = dialogService;

            //Title = "Browse";
            ListOfCost = new List<DataCostList>();

            KotaAsal = Item.kota_asal_id;
            KotaTuju = Item.kota_tujuan_id;
            Berat = Item.berat;
            
            Ket = Item.kota_asal_nama + " Ke " + Item.kota_tujuan_nama + " @" + Item.berat + " gram";

            AddCommand = new Command(() =>
            {
                DependencyService.Get<IInterstitialAds>().ShowAds();
                //_dialogService.ShowMessage("Hello from FAB button", "ViewModel");
            });

            LoadCostsCommand = new Command(async () => await ExecuteLoadCostsCommand());    

        }

        public Task<Cost> GetTasksAsync()
        {
            return DSCost.RefreshDataAsync(KotaAsal, KotaTuju, Berat, "jne");
        }

        async Task ExecuteLoadCostsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ListOfCost.Clear();
                var costs = await GetTasksAsync();

                 //KotaAsal = costs.rajaongkir.origin_details.city_name;
                 //KotaTuju = costs.rajaongkir.destination_details.city_name;
                 //Berat = costs.rajaongkir.query.weight;


                List<DataCostList> list = new List<DataCostList>();
                foreach (var cost in costs.rajaongkir.results)
                {                    
                    DataCostList sList = new DataCostList(); 

                    foreach (var serv in cost.costs)
                    {
                        double tarif = 0;
                        string ket = "";
                        foreach (var val in serv.cost)
                        {
                            tarif = Convert.ToDouble(val.value);
                            ket = "Note: "+ val.note + " Etd : " + val.etd;
                        }

                        sList.Add(new DataCost.Costs() {
                            service = serv.service,
                            description = serv.description,
                            tarif = tarif,
                            keterangan = ket
                        });                        
                    }                     
                            
                    sList.Heading = cost.code.ToUpper() + " - " + cost.name;
                                       
                    list.Add(sList);                    
                }

                ListOfCost = list;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}