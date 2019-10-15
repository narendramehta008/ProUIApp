using BaseLibs.Handlers.BindManager;
using BaseUI.MainViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BaseUI.ContentViewModel
{
   public class FBContentPageViewModel : BindableObject
    {
        private Lazy<UserControl> _FBMainPage;
        private Lazy<UserControl> _FBMediaPage;

        public Lazy<UserControl> FBMainPage
        {
            get { return _FBMainPage; }
            set { SetProperty(ref _FBMainPage, value); }
        }

        public Lazy<UserControl> FBMediaPage
        {
            get { return _FBMediaPage; }
            set { SetProperty(ref _FBMediaPage, value); }
        }

    }
}
