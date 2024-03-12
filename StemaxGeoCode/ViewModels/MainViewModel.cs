using StemaxGeoCode.Data;
using StemaxGeoCode.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.ViewModels
{
    class MainViewModel:AbstractViewModel
    {
        private iRepository repository;
        private iMapUriBuilder mapUriBuilder;
        private Uri mapUri;

        public ObservableCollection<iObjectData> Objects { get; private set; }

        public Uri MapUri
        {
            get { return mapUri; }
            private set {
                if (mapUri != value)
                {
                    mapUri = value;
                    OnPropertyChanged(nameof(MapUri));
                }               
            }
        }

        public bool MapEnabled => !mapUriBuilder.Center.IsZero;

        public MainViewModel(iRepository repository, iMapUriBuilder mapUriBuilder)
        {
            this.repository = repository;
            this.mapUriBuilder = mapUriBuilder;
            Objects = new ObservableCollection<iObjectData>(repository.loadAllObjects());
            MapUri = mapUriBuilder.Build();
        }
    }
}