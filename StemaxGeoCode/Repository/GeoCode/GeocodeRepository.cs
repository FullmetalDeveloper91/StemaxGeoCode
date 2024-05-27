using StemaxGeoCode.Data;
using StemaxGeoCode.DataSource.GeoCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Repository.GeoCode
{
    class GeocodeRepository : iGeocodeRepository
    {
        private iGeoApiClient dataSource;

        public GeocodeRepository(iGeoApiClient dataSource)
        {
            this.dataSource = dataSource;
        }

        public async Task<List<(string name, Coordinate coordinate)>> GetCoordinateByAdressAsync(string adress)
        {
            return await dataSource.GetGeoByAdressAsync(adress);
        }
    }
}