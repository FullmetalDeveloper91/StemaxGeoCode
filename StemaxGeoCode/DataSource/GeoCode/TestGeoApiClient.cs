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
        public async Task<List<(string name, Coordinate coordinate)>> GetGeoByAdressAsync(string adress)
        {
            Random rnd = new Random();
            await Task.Delay(3);
            //throw new Exception("Geo service is offline");
            return new List<(string name, Coordinate coordinate)> { 
                (adress, new Coordinate(82.0 + rnd.NextDouble(), 55.0 + rnd.NextDouble())),
                (adress, new Coordinate(82.0 + rnd.NextDouble(), 55.0 + rnd.NextDouble())),
                (adress, new Coordinate(82.0 + rnd.NextDouble(), 55.0 + rnd.NextDouble()))
            };
        }
    }
}
