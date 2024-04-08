using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace StemaxGeoCode.Data
{
    class ObjectData : iObjectData
    {
        private Coordinate coordinate;

        public int Id { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Coordinate Coordinate { get => coordinate; set { if (coordinate == value) return; coordinate = value;  } }

        public ObjectData(int id, string name, string adress, Coordinate? coordinate = null) {
            this.Id = id;
            this.Name = name;
            this.Address = adress;
            this.Coordinate = coordinate ?? new Coordinate(0, 0);
        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}