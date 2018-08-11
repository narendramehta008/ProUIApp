using BaseUI.ContentViewModel;
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
    /// Interaction logic for TDContentPage.xaml
    /// </summary>
    public partial class TDContentPage : UserControl
    {
        TDContentPageViewModel objTDViewModel = new TDContentPageViewModel();

        public TDContentPage()
        {
            InitializeComponent();
            InitializeValue();

        }

        private void InitializeValue()
        {
            try
            {
                DataContext = objTDViewModel;
            }
            catch (Exception ex) { }
        }

        private static TDContentPage obj;
        public static TDContentPage getObj()
        {
            return obj ?? (obj = new TDContentPage());
        }
    }
}
