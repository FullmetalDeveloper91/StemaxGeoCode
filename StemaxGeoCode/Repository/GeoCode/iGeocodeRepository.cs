using StemaxGeoCode.Data;

namespace StemaxGeoCode.Repository.GeoCode
{
    interface iGeocodeRepository
    {
        public Task<List<(string name,Coordinate coordinate)>> GetCoordinateByAdressAsync(string adress);
    }
}
