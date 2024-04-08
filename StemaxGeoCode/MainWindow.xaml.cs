using StemaxGeoCode.Data;
using StemaxGeoCode.Repository.Addresses;
using StemaxGeoCode.ViewModels;
using System.Windows;

namespace StemaxGeoCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Coordinate startCoord = new Coordinate(82.91, 55.06);
            //DataContext = new MainViewModel(new TestObjectsRepository(), new DoubleGisMapUriBuilder(15,500,350, new Coordinate(), new Coordinate()));
            DataContext = new MainViewModel(new DbObjectRepository("postgres", "root"), new DoubleGisMapUriBuilder(15, 500, 350, startCoord, startCoord));
        }
    }
}