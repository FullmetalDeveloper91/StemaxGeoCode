using StemaxGeoCode.Data;
using StemaxGeoCode.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Repository
{
    class GeocodeRepository : iGeocodeRepository
    {
        private iGeoApiClient dataSource;

        public GeocodeRepository(iGeoApiClient dataSource)
        {
            this.dataSource = dataSource;
        }

        public async Task<Coordinate> GetCoordinateByAdressAsync(string adress)
        {
            var response = await dataSource.GetGeoByAdressAsync(adress);
            string[] pos = response.response.GeoObjectCollection.featureMember[0].GeoObject.Point.pos.Split(' ');
            var latitude = Double.Parse(pos[0]);
            var longitude = Double.Parse(pos[1]);
            return new Coordinate(latitude, longitude);
        }
    }
}
