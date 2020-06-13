using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KurirOngkir.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Diagnostics;

namespace KurirOngkir.Services
{
    /**
    * Kurir Ongkir App
    *
    * @package  Xamarin Kurir Ongkir
    * @author   Ketut Ugi Diranta <nugi.dirta@gmail.com>
    */
    public class MockDataKota : IDataStore<Kota>
    {
        HttpClient client;

        Kota items;

        public MockDataKota()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }
        
        public async Task<Kota> RefreshDataAsync()
        {
            items = new Kota();

            string RestUrl = "https://api.rajaongkir.com/starter/city?";
            var uri = new Uri(string.Format(RestUrl + "&key={0}", "dbe9480ac793c8aca788b037dbafaecc"));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<Kota>(content);
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return items;
        }
        

    }
}