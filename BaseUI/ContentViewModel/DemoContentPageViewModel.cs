using BaseLibs.Handlers.BindManager;
using BaseUI.EnumsPack;
using BaseUI.MainViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BaseUI.ContentViewModel
{
   public class DemoContentPageViewModel : BindableObject
    {
        private List<TabItemTemplate> _ListTabItemTemplate = new List<TabItemTemplate>();

        public List<TabItemTemplate> ListTabItemTemplate
        {
            get { return _ListTabItemTemplate; }
            set { SetProperty(ref _ListTabItemTemplate, value); }
        }

        private string _SelectedTabName = DemoTabs.SimpleMaterial.ToString();

        public string SelectedTabName
        {
            get { return _SelectedTabName; }
            set { SetProperty(ref _SelectedTabName, value); }
        }

    }
}
