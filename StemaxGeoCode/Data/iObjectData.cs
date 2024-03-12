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
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}
