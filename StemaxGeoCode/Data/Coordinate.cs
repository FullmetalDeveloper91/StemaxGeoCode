using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.Data
{
    class Coordinate
    {
        private double longitude = 0;
        private double latitude = 0;        

        public const double MIN_LAT = -180;
        public const double MIN_LON = -90;
        public const double MAX_LAT = 180;
        public const double MAX_LON = 90;

        public Coordinate(){}

        public Coordinate (double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double Longitude
        {
            get => longitude;
            set
            {
                if (value < MIN_LON || value > MAX_LON)
                    throw new ArgumentOutOfRangeException($"Latitude must be between {MIN_LON} and {MAX_LON}");
                longitude = value;
            }
        }

        public double Latitude 
        {
            get => latitude;
            set
            {
                if (value < MIN_LAT || value > MAX_LAT) 
                    throw new ArgumentOutOfRangeException($"Latitude must be between {MIN_LAT} and {MAX_LAT}");
                latitude = value;
            } 
        }        

        public bool IsZero => latitude < 1 && longitude < 1;

        public override string ToString() =>
            $"{longitude.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"))},{latitude.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"))}";
        
    }
}
