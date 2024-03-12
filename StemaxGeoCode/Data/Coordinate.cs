using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Data
{
    class Coordinate
    {
        private double latitude = 0;
        private double longitude = 0;

        public const double MIN_LATLON = 0;
        public const double MAX_LAT = 90;
        public const double MAX_LON = 180;

        public Coordinate(){}

        public Coordinate (double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude 
        {
            get => latitude;
            set
            {
                if (value < MIN_LATLON || value > MAX_LAT) 
                    throw new ArgumentOutOfRangeException($"Latitude must be between {MIN_LATLON} and {MAX_LAT}");
                latitude = value;
            } 
        }
        public double Longitude
        {
            get => longitude;
            set
            {
                if (value < MIN_LATLON || value > MAX_LAT)
                    throw new ArgumentOutOfRangeException($"Latitude must be between {MIN_LATLON} and {MAX_LON}");
                longitude = value;
            }
        }

        public bool IsZero => latitude < 1 && longitude < 1;

        public override string ToString() =>
            $"{latitude.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"))},{longitude.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"))}";
        
    }
}
