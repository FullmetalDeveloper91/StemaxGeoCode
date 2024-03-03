using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Data
{
    class ObjectData : iObjectData
    {
        public ObjectData(string Adress) { this.Adress = Adress; }
        public string Adress { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
