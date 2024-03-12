using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace StemaxGeoCode.Data
{
    class ObjectData : iObjectData
    {
        public int Id { get; }
        public ObjectData(string Adress) { this.Adress = Adress; }
        public string Adress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ObjectData(int id, string adress) {
            this.Id = id;
            this.Adress = adress;
        }

        public override string ToString()
        {
            return $"{Id} {Adress}";
        }
    }
}