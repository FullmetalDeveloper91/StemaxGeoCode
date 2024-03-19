using StemaxGeoCode.Data.GeoCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.DataSource
{
    internal interface iGeoApiClient
    {
        public Task<Root?> GetGeoByAdressAsync(string adress);
    }
}
