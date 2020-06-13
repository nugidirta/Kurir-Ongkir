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
    public class MockDataCost 
    {
        HttpClient client;
      
        Cost items;

        //string Origin = "501";
        //string Destination = "114";
        //double Weight = 1700;
        //string Courier = "jne";

        public MockDataCost()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));//ACCEPT header

            //Origin = origin;
            //Destination = destination;
            //Weight = weight;
            //Courier = courier;

        }
        
        public async Task<Cost> RefreshDataAsync(string origin, string destination, double weight, string courier)
        {
            items = new Cost();

            string RestUrl = "https://api.rajaongkir.com/starter/cost";
            
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, RestUrl);
            request.Headers.Add("key", "dbe9480ac793c8aca788b037dbafaecc");
            request.Content = new StringContent(string.Format(
                "origin={0}&destination={1}&weight={2}&courier={3}", origin, destination, weight, courier),
                Encoding.UTF8,
                "application/x-www-form-urlencoded");//CONTENT-TYPE header


            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<Cost>(content);
                    
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