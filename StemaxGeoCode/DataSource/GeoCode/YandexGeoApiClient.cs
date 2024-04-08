using RestSharp;
using StemaxGeoCode.Data;
using StemaxGeoCode.Data.GeoCode;

namespace StemaxGeoCode.DataSource.GeoCode
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

        async public Task<Coordinate> GetGeoByAdressAsync(string adress)
        {
            var restRequest = new RestRequest()
                .AddParameter("apikey", apiKey)
                .AddParameter("geocode", adress.Replace(' ', '+'))
                .AddParameter("format", "json");

            var response = await client.GetAsync<Root>(restRequest);
            var responses = response!.response.GeoObjectCollection.featureMember;
            if (responses.Count <= 0)
                return new Coordinate();
            string[] pos = responses.First().GeoObject.Point.pos.Split(' ');
            var latitude = double.Parse(pos[1].Replace('.', ','));
            var longitude = double.Parse(pos[0].Replace('.', ','));

            return new Coordinate(longitude, latitude);
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
