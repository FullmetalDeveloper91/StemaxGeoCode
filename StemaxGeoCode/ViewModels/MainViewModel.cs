using StemaxGeoCode.Data;
using StemaxGeoCode.DataSource;
using StemaxGeoCode.Repository;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace StemaxGeoCode.ViewModels
{
    enum DataLoadingState { isLoading, isLoaded, isError }
    class MainViewModel : AbstractViewModel
    {
        private iObjectsRepository repository;
        private iGeocodeRepository geocodeRepository;
        private iMapUriBuilder mapUriBuilder;
        private Uri mapUri;
        private iObjectData selectedObject;

        private object objectsCollectionLock = new object();

        public ObservableCollection<iObjectData> Objects { get; private set; }
        public DataLoadingState State { get; private set; } = DataLoadingState.isLoaded;

        public Uri MapUri
        {
            get => mapUri;
            private set
            {
                if (mapUri == value) return;
                mapUri = value;
                OnPropertyChanged();
            }
        }

        public iObjectData SelectedObject
        {
            get => selectedObject;
            set
            {
                if (value == selectedObject) return;
                selectedObject = value;
                //RebuildMapUri(SelectedObject);
                OnPropertyChanged();
            }
        }

        public MainViewModel(iObjectsRepository repository, iMapUriBuilder mapUriBuilder)
        {
            Objects = [];
            BindingOperations.EnableCollectionSynchronization(Objects, objectsCollectionLock);
            this.repository = repository;
            this.geocodeRepository = new GeocodeRepository(new YandexGeoApiClient(App.YA_API_KEY));
            this.mapUriBuilder = mapUriBuilder;

            repository.loadAllObjects().ContinueWith(x =>
            {
                foreach (var obj in x.Result)
                {
                    Objects.Add(obj);
                }
                GetCoordByObject(Objects[0]);
            });
            MapUri = mapUriBuilder.Build();


        }

        public bool MapEnabled => !mapUriBuilder.Center.IsZero;

        private void RebuildMapUri(iObjectData objectData)
        {
            mapUriBuilder.Marker = objectData.coordinate;
            mapUriBuilder.Center = mapUriBuilder.Marker;
            MapUri = mapUriBuilder.Build();
        }

        private void GetCoordByObject(iObjectData obj)
        {
            geocodeRepository.GetCoordinateByAdressAsync(obj.Adress).ContinueWith(x =>
            {
                obj.coordinate = x.Result;
            });
        }

        private void SaveObjectsFromList(List<iObjectData> objects)
        {

        }
    }
}