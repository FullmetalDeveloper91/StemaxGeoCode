using StemaxGeoCode.Data;

namespace StemaxGeoCode.Repository
{
    interface iObjectsRepository
    {
        public Task<List<iObjectData>> loadAllObjects();
        public void saveAllObjects();
        public void saveObject(int id);
    }
}