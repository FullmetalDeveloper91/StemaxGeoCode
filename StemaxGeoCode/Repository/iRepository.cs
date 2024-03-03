using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Repository
{
    interface iRepository
    {
        public void loadAllObjects();
        public void saveAllObjects();
        public void saveObject(int id);
    }
}
