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
using BaseUI.MainViewModel;
using ProUIApp.View.FileIOView;

namespace ProUIApp.View.ContentView
{
    /// <summary>
    /// Interaction logic for FileIOContentPage.xaml
    /// </summary>
    public partial class FileIOContentPage : UserControl
    {
        FileIOContentPageViewModel objFileIOViewModel = new FileIOContentPageViewModel();

        public FileIOContentPage()
        {
            InitializeComponent();
            InitializeValue();

        }

        private void InitializeValue()
        {
            try
            {
                DataContext = objFileIOViewModel;

                objFileIOViewModel.FileViewerTab = new Lazy<UserControl>(FileViewer.getObj);
                objFileIOViewModel.FileUpdaterTab = new Lazy<UserControl>(FileUpdater.getObj);
                objFileIOViewModel.ImageViewerTab = new Lazy<UserControl>(ImageViewer.getObj);
                objFileIOViewModel.RegexCheckTab = new Lazy<UserControl>(RegexCheck.getObj);

            }
            catch (Exception ex) { }
        }

        private static FileIOContentPage obj;
        public static FileIOContentPage getObj()
        {
            return obj ?? (obj = new FileIOContentPage());
        }
    }
}
