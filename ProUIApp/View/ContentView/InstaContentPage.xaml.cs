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
    /// Interaction logic for InstaContentPage.xaml
    /// </summary>
    public partial class InstaContentPage : UserControl
    {
        InstaContentPageViewModel objInstaViewModel = new InstaContentPageViewModel();

        public InstaContentPage()
        {
            InitializeComponent();
            InitializeValue();

        }

        private void InitializeValue()
        {
            try
            {
                DataContext = objInstaViewModel;
            }
            catch (Exception ex) { }
        }

        private static InstaContentPage obj;
        public static InstaContentPage getObj()
        {
            return obj ?? (obj = new InstaContentPage());
        }
    }
}
