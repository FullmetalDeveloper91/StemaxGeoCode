using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Data
{
    interface iObjectData
    {
        int Id { get; }
        string Adress { get; set; }
        public Coordinate coordinate { get; set; }
    }
}
