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
    public class AccountContentPageViewModel : BindableObject
    {
        private Lazy<UserControl> _SelectedTab = new Lazy<UserControl>();


        public Lazy<UserControl> SelectedTab
        {
            get { return _SelectedTab; }
            set { SetProperty(ref _SelectedTab, value); }
        }

    }
}
