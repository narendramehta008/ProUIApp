using BaseUI.MainViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BaseUI.ContentViewModel
{
   public class FileIOContentPageViewModel : BindableObject
    {
        private Lazy<UserControl> _FileViewerTab;
        private Lazy<UserControl> _FileUpdaterTab;
        private Lazy<UserControl> _ImageViewerTab;
        private Lazy<UserControl> _RegexCheckTab;


        public Lazy<UserControl> FileViewerTab
        {
            get { return _FileViewerTab; }
            set { SetProperty(ref _FileViewerTab, value); }
        }
        public Lazy<UserControl> FileUpdaterTab
        {
            get { return _FileUpdaterTab; }
            set { SetProperty(ref _FileUpdaterTab, value); }
        }
        public Lazy<UserControl> ImageViewerTab
        {
            get { return _ImageViewerTab; }
            set { SetProperty(ref _ImageViewerTab, value); }
        }
        public Lazy<UserControl> RegexCheckTab
        {
            get { return _RegexCheckTab; }
            set { SetProperty(ref _RegexCheckTab, value); }
        }


    }
}
