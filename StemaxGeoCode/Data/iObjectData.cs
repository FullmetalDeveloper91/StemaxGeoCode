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
        string Name { get; }
        string Address { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}
