using RestSharp;
using StemaxGeoCode.Data.GeoCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.DataSource
{
    class YandexGeoApiClient : iGeoApiClient, IDisposable
    {
        private string apiKey = "";

        private const string BASE_URI = "https://geocode-maps.yandex.ru/1.x";
        
        private RestClientOptions options;
        private RestClient client;
        public YandexGeoApiClient(string apiKey) 
        { 
            this.apiKey = apiKey;
            options = new RestClientOptions(BASE_URI);
            client = new RestClient(options);
        }
        public Task<Root?> GetGeoByAdressAsync(string adress)
        {
            var restRequest = new RestRequest()
                .AddParameter("apikey", this.apiKey)
                .AddParameter("geocode", adress.Replace(' ', '+'))
                .AddParameter("format", "json");
            var request = restRequest.ToString();
            return client.GetAsync<Root?>(restRequest);
            //return client.GetJsonAsync<Root?>("https://geocode-maps.yandex.ru/1.x/?apikey=37152a3e-ca9c-4bd3-8e76-dd10881d9e63&geocode=Новосибирск, 1-я Ракитная, 1А&format=json");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
