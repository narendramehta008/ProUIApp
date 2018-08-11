using BaseUI.ContentViewModel;
using BaseUI.EnumsPack;
using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProUIApp.View.ContentView
{
    /// <summary>
    /// Interaction logic for DemoContentPage.xaml
    /// </summary>
    public partial class DemoContentPage : UserControl
    {
        DemoContentPageViewModel DemoViewModel = new DemoContentPageViewModel();

        public DemoContentPage()
        {
            InitializeComponent();
            InitializeValue();

        }

        private void InitializeValue()
        {
            try
            {
                DataContext = DemoViewModel;
            }
            catch (Exception ex) { }
        }

        private static DemoContentPage obj;
        public static DemoContentPage getObj()
        {
            return obj ?? (obj = new DemoContentPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    DemoViewModel.SelectedTabName = DemoTabs.SimpleMaterial.ToString();
                    DemoTabControl.SelectedIndex = index;
                    break;
                case 1:
                    DemoViewModel.SelectedTabName = DemoTabs.SimpleTips.ToString();
                    DemoTabControl.SelectedIndex = index;
                    break;
                //case 2:
                //    GridMain.Background = Brushes.CadetBlue;
                //    break;
                //case 3:
                //    GridMain.Background = Brushes.DarkBlue;
                //    break;
                //case 4:
                //    GridMain.Background = Brushes.Firebrick;
                //    break;
                //case 5:
                //    GridMain.Background = Brushes.Gainsboro;
                //    break;
                //case 6:
                //    GridMain.Background = Brushes.HotPink;
                //    break;
                default:
                    ModernDialog.ShowMessage("Not Available\t\t", "ProUI", MessageBoxButton.OK).ToString();
                    break;
            }
        }
    }
}
