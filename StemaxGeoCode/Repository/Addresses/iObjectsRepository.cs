using StemaxGeoCode.Data;

namespace StemaxGeoCode.Repository.Addresses
{
    interface iObjectsRepository
    {
        public Task<List<iObjectData>> loadAllObjects();
        public void saveAllObjects(List<iObjectData> objects);
        public void saveObject(iObjectData obj);
    }
}