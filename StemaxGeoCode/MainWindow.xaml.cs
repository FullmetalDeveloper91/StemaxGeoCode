using StemaxGeoCode.Data;
using StemaxGeoCode.Repository;
using StemaxGeoCode.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

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
            DataContext = new MainViewModel(new DbObjectRepository(), new DoubleGisMapUriBuilder(15, 500, 350, new Coordinate(), new Coordinate()));
        }

        private void adressesList_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}