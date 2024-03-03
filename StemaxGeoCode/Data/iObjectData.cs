using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Data
{
    interface iObjectData
    {
        string Adress { get; set; }
        double latitude { get; set; }
        double longitude { get; set; }
    }
}
