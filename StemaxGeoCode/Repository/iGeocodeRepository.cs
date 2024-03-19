using StemaxGeoCode.Data;

namespace StemaxGeoCode.Repository
{
    interface iGeocodeRepository
    {
        public Task<Coordinate> GetCoordinateByAdressAsync(string adress);
    }
}
