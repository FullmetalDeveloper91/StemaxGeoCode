using RestSharp;
using StemaxGeoCode.Data;
using StemaxGeoCode.Data.GeoCode;

namespace StemaxGeoCode.DataSource.GeoCode
{
    class YandexGeoApiClient : iGeoApiClient, IDisposable
    {
        private readonly string apiKey = "";

        private const string BASE_URI = "https://geocode-maps.yandex.ru/1.x";

        private readonly RestClientOptions options;
        private readonly RestClient client;

        public YandexGeoApiClient(string apiKey)
        {
            this.apiKey = apiKey;
            options = new RestClientOptions(BASE_URI);
            client = new RestClient(options);
        }

        async public Task<List<(string name, Coordinate coordinate)>> GetGeoByAdressAsync(string adress)
        {
            var GeoObjects = new List<(string name, Coordinate coordinate)>();
            var restRequest = new RestRequest()
                .AddParameter("apikey", apiKey)
                .AddParameter("geocode", adress.Replace(' ', '+'))
                .AddParameter("format", "json");

            var response = await client.GetAsync<Root>(restRequest);
            var featureMembers = response!.response.GeoObjectCollection.featureMember;

            if (featureMembers.Count <= 0)
                GeoObjects.Add((adress, new Coordinate()));
            else
            {
                foreach (var geoObject in featureMembers)
                {
                    string[] pos = geoObject.GeoObject.Point.pos.Split(' ');
                    var longitude = double.Parse(pos[0].Replace('.', ','));
                    var latitude = double.Parse(pos[1].Replace('.', ','));

                    GeoObjects.Add((geoObject.GeoObject.name, new Coordinate(longitude, latitude)));
                }
            }
            return GeoObjects;
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
