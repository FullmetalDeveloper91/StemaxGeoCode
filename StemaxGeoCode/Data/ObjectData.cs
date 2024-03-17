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
        public string Adress { get; set; }
        public Coordinate coordinate { get; set; }

        public ObjectData(int id, string adress, Coordinate? coordinate = null) {
            this.Id = id;
            this.Adress = adress;
            this.coordinate = coordinate ?? new Coordinate(0, 0);
        }

        public override string ToString()
        {
            return $"{Id} {Adress}";
        }
    }
}