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

namespace KurirOngkir.ViewModels
{
    public class KotasViewModel : BaseViewModel
    {
        
        public Command LoadKotasCommand { get; set; }
        //public ICommand CariCommand { get; private set; }

        public ObservableCollection<Kota.Results> Kotas { get; set; }

        public KotasViewModel()
        {
            Title = "Browse";
            Kotas = new ObservableCollection<Kota.Results>();
            LoadKotasCommand = new Command(async () => await ExecuteLoadKotasCommand());

            //CariCommand = new Command(() =>
            //{
                
            //});

        }

        public Task<Kota> GetTasksAsync()
        {
            return DSKota.RefreshDataAsync();
        }

        async Task ExecuteLoadKotasCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Kotas.Clear();
                var kotas = await GetTasksAsync();
                
                foreach (var kota in kotas.rajaongkir.results)
                {
                    var mock = new Kota.Results { city_id = kota.city_id, city_name = kota.city_name };
                    Kotas.Add(mock);
                }

          

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