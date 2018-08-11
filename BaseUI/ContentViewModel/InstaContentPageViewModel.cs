using BaseUI.MainViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUI.ContentViewModel
{
   public class InstaContentPageViewModel : BindableObject
    {
        private List<TabItemTemplate> _ListTabItemTemplate = new List<TabItemTemplate>();


        public List<TabItemTemplate> ListTabItemTemplate
        {
            get { return _ListTabItemTemplate; }
            set { SetProperty(ref _ListTabItemTemplate, value); }
        }

    }
}
