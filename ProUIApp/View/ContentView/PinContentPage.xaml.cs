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
    /// Interaction logic for PinContentPage.xaml
    /// </summary>
    public partial class PinContentPage : UserControl
    {
        PinContentPageViewModel objPinViewModel = new PinContentPageViewModel();

        public PinContentPage()
        {
            InitializeComponent();
            InitializeValue();

        }

        private void InitializeValue()
        {
            try
            {
                DataContext = objPinViewModel;
            }
            catch (Exception ex) { }
        }

        private static AccountContentPage obj;
        public static AccountContentPage getObj()
        {
            return obj ?? (obj = new AccountContentPage());
        }
    }
}
