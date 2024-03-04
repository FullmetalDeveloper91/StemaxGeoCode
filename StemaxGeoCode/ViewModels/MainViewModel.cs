using StemaxGeoCode.Data;
using StemaxGeoCode.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.ViewModels
{
    internal class MainViewModel
    {
        private iRepository repository;
        private List<ObjectData> objects;

        public IEnumerable<ObjectData> Objects {  get { return objects.ToImmutableList<ObjectData>(); } }
        public Uri mapUri { get; }

        public MainViewModel(iRepository repository)
        {
            this.repository = repository;
            objects = new();
            mapUri = new Uri("http://static.maps.2gis.com/1.0?center=82.911182,55.058883&zoom=15&size=500,350");
        }
    }
}
