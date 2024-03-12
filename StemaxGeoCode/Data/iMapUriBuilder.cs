using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Data
{
    internal interface iMapUriBuilder
    {
        int Zoom {  get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Coordinate Center { get; set; }
        Coordinate Marker { get; set; }

        public Uri Build();
    }
}
