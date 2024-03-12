﻿using StemaxGeoCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Repository
{
    interface iRepository
    {
        public List<iObjectData> loadAllObjects();
        public void saveAllObjects();
        public void saveObject(int id);
    }
}
