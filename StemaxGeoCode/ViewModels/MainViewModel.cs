using StemaxGeoCode.Data;
using StemaxGeoCode.DataSource;
using StemaxGeoCode.DataSource.GeoCode;
using StemaxGeoCode.Repository.Addresses;
using StemaxGeoCode.Repository.GeoCode;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace StemaxGeoCode.ViewModels
{
    enum DataLoadingState { isLoading, isLoaded, isError }
    class MainViewModel : AbstractViewModel
    {
        private iObjectsRepository repository;
        private iGeocodeRepository geocodeRepository;
        private iMapUriBuilder mapUriBuilder;       
        private iObjectData selectedObject;
        private CancellationToken cancellationToken;

        private object objectsCollectionLock = new object();
        public ObservableCollection<iObjectData> Objects { get; private set; }

        public DataLoadingState State { get; private set; } = DataLoadingState.isLoaded;

        #region for progressbar count
        private int minLoadProgress = 0;
        private int maxLoadProgress = int.MaxValue;
        private int currentLoadProgress = 0;

        public int MinLoadProgress { get => minLoadProgress; private set { if (minLoadProgress == value) return; minLoadProgress = value; OnPropertyChanged(); }  }
        public int MaxLoadProgress { get => maxLoadProgress; private set { if (maxLoadProgress == value) return; maxLoadProgress = value; OnPropertyChanged(); } }        
        public int CurrentLoadProgress { get => currentLoadProgress; private set { if (currentLoadProgress == value) return; currentLoadProgress = value; OnPropertyChanged(); } }
        #endregion

        private Uri mapUri;
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
                RebuildMapUri(SelectedObject);
                OnPropertyChanged();
            }
        }

        #region commands
        private ICommand getCoordinatesCommand;       

        public ICommand GetCooordinatesCommand
        {
            get
            {
                return getCoordinatesCommand ?? (
                    getCoordinatesCommand = new DelegateCommand(x =>
                    {
                        GetCoordByAllObjects(cancellationToken);
                    }));
            }
        }

        #endregion

        public MainViewModel(iObjectsRepository repository, iMapUriBuilder mapUriBuilder)
        {
            Objects = [];
            BindingOperations.EnableCollectionSynchronization(Objects, objectsCollectionLock);
            this.repository = repository;
            //this.geocodeRepository = new GeocodeRepository(new YandexGeoApiClient(App.YA_API_KEY));
            geocodeRepository = new GeocodeRepository(new TestGeoApiClient());
            this.mapUriBuilder = mapUriBuilder;

            repository.loadAllObjects().ContinueWith(x =>
            {
                foreach (var obj in x.Result)
                {
                    Objects.Add(obj);
                }
            });
            MapUri = mapUriBuilder.Build();
        }       

        private void RebuildMapUri(iObjectData objectData)
        {
            mapUriBuilder.Marker = objectData.Coordinate;
            mapUriBuilder.Center = mapUriBuilder.Marker;
            MapUri = mapUriBuilder.Build();
        }

        private void GetCoordByObject(iObjectData obj)
        {
            geocodeRepository.GetCoordinateByAdressAsync(obj.Address).ContinueWith(x =>
            {
                obj.Coordinate = x.Result;
            });
        }

        async private void GetCoordByAllObjects(CancellationToken cancellation)
        {
            this.MinLoadProgress = 0;
            this.MaxLoadProgress = Objects.Count;
            this.CurrentLoadProgress = this.MinLoadProgress;

            State = DataLoadingState.isLoading;

            foreach (var obj in Objects)
            {
                if (cancellation.IsCancellationRequested)
                    break;
                if (obj.Coordinate.IsZero)
                {
                    //geocodeRepository.GetCoordinateByAdressAsync(obj.Adress).ContinueWith(x => { obj.coordinate = x.Result; CurrentLoadProgress++; });
                    obj.Coordinate = await geocodeRepository.GetCoordinateByAdressAsync(obj.Address);
                    CurrentLoadProgress++;
                }
                else CurrentLoadProgress++;
            }

            State = DataLoadingState.isLoaded;
            CurrentLoadProgress = MinLoadProgress;
        }

        private void SaveObjectsFromList(List<iObjectData> objects)
        {
            
        }
    }
}