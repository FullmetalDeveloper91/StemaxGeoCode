using StemaxGeoCode.Data;
using StemaxGeoCode.Data.GeoCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.DataSource.GeoCode
{
    internal interface iGeoApiClient
    {
        public Task<Coordinate> GetGeoByAdressAsync(string adress);
    }
}
