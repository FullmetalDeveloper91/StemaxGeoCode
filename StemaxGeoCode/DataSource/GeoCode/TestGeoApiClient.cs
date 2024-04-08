using StemaxGeoCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.DataSource.GeoCode
{
    class TestGeoApiClient : iGeoApiClient
    {
        public async Task<Coordinate> GetGeoByAdressAsync(string adress)
        {
            Random rnd = new Random();
            await Task.Delay(3);
            return new Coordinate(82.0 + rnd.NextDouble(), 55.0 + rnd.NextDouble());
        }
    }
}
