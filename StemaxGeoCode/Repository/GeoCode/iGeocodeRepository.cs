using StemaxGeoCode.Data;

namespace StemaxGeoCode.Repository.GeoCode
{
    interface iGeocodeRepository
    {
        public Task<Coordinate> GetCoordinateByAdressAsync(string adress);
    }
}
