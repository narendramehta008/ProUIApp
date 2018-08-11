using BaseUI.ContentViewModel;
using ProUIApp.View.FBView;
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
    /// Interaction logic for FBContentPage.xaml
    /// </summary>
    public partial class FBContentPage : UserControl
    {
        FBContentPageViewModel objFBViewModel = new FBContentPageViewModel();

        public FBContentPage()
        {
            InitializeComponent();
            InitializeValue();
        }

        private void InitializeValue()
        {
            try
            {
                DataContext = objFBViewModel;
                objFBViewModel.FBMainPage = new Lazy<UserControl>(FBMainPage.getObj);
                objFBViewModel.FBMediaPage = new Lazy<UserControl>(FBMedia.getObj);
            }
            catch (Exception ex) { }
        }

        private static FBContentPage obj;
        public static FBContentPage getObj()
        {
            return obj ?? (obj = new FBContentPage());
        }
    }
}
