using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Data
{
    class DoubleGisMapUriBuilder : iMapUriBuilder
    {
        private int zoom;
        private int width;
        private int height;

        private const int MAX_ZOOM = 15;
        private const int MIN_ZOOM = 1;
        private const int MAX_SIZE = 1000;
        private const int MIN_SIZE = 100;

        public DoubleGisMapUriBuilder(int zoom, int width, int height, Coordinate center, Coordinate marker)
        {
            Zoom = zoom;
            Width = width;
            Height = height;
            Center = center;
            Marker = marker;
        }

        public int Zoom
        {
            get => zoom;
            set { 
                if(value < MIN_ZOOM || value > MAX_ZOOM)
                    throw new ArgumentOutOfRangeException($"Zoom must be between {MIN_ZOOM} and {MAX_ZOOM}");
                zoom = value; 
            }
        }

        public int Width { 
            get => width; 
            set
            {
                if (value < MIN_SIZE|| value > MAX_SIZE)
                    throw new ArgumentOutOfRangeException($"Map size bust be between {MIN_SIZE} and {MAX_SIZE}");
                width = value;                
            }
        }
        public int Height {
            get => height;
            set
            {
                if (value < MIN_SIZE || value > MAX_SIZE)
                    throw new ArgumentOutOfRangeException($"Map size bust be between {MIN_SIZE} and {MAX_SIZE}");
                height = value;
            }
        }
       
        public Coordinate Center { get; set; }
        public Coordinate Marker { get; set; }

        public Uri Build()
        {
            return new Uri($"http://static.maps.2gis.com/1.0?zoom={Zoom}&size={Width},{Height}&center={Center}&markers={Marker}");
        }
    }
}
