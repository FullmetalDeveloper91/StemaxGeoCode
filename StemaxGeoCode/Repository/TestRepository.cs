using StemaxGeoCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Repository
{
    internal class TestRepository : iRepository
    {
        private List<iObjectData> objects;

        public TestRepository() {
            objects = new List<iObjectData>
            {
                new ObjectData(1, "1-я Ракитная, 1А", new Coordinate(82.888,55.0164)),
                new ObjectData(2, "2 - я Прокопьевская, 35 / 2", new Coordinate(82.982683,54.944425))
            };            
        }

        async public Task<List<iObjectData>> loadAllObjects()
        {
            await Task.Delay(2000);
            return objects;
        }

        public void saveAllObjects()
        {
            throw new NotImplementedException();
        }

        public void saveObject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
