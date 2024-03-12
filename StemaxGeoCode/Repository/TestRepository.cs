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
                new ObjectData(1, "1-я Ракитная, 1А"),
                new ObjectData(2, "2 - я Прокопьевская, 35 / 2")
            };
        }

        public List<iObjectData> loadAllObjects()
        {
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
