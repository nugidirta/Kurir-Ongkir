using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using KurirOngkir.Models;
using KurirOngkir.Views;
using System.Collections.Generic;
using KurirOngkir.Services;

namespace KurirOngkir.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        
        public Command LoadItemsCommand { get; set; }

        public class DataItem
        {
            public string province_id { get; set; }
            public string province { get; set; }
        }

        public ObservableCollection<DataItem> Items { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<DataItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
    
            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        public Task<Item> GetTasksAsync()
        {
            return DataStore.RefreshDataAsync();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await GetTasksAsync();
                
                foreach (var item in items.rajaongkir.results)
                {
                    var mock = new DataItem { province_id = item.province_id, province = item.province };
                    Items.Add(mock);
                }

          
                
                             

            

                //items = new List<Item>();
                //var mockItems = new List<Item>
                //{
                //    new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                //    new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //    new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //    new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
                //};

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