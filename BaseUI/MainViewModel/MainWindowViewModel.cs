using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BaseUI.MainViewModel
{
   public class MainWindowViewModel : BindableObject
    {
        private List<TabItemTemplate> _ListTabItemTemplate = new List<TabItemTemplate>();

        private Visibility _AccountTabVisibility;
        private Visibility _FBTabVisibility = Visibility.Collapsed;
        private Visibility _InstaTabVisibility = Visibility.Collapsed;
        private Visibility _FileIOTabVisibility = Visibility.Collapsed;
        private Visibility _DemoTabVisibility = Visibility.Collapsed;
        //private UserControl _MainUserControl;



        private Lazy<UserControl> _CurrentTab;// = new Lazy<UserControl>();

        public List<TabItemTemplate> ListTabItemTemplate
        {
            get { return _ListTabItemTemplate; }
            set { SetProperty(ref _ListTabItemTemplate, value); }
        }

        public Visibility AccountTabVisibility
        {
            get { return _AccountTabVisibility; }
            set { SetProperty(ref _AccountTabVisibility,value); }
        }
        public Visibility FBTabVisibility
        {
            get { return _FBTabVisibility; }
            set { SetProperty(ref _FBTabVisibility, value); }
        }
        public Visibility InstaTabVisibility
        {
            get { return _InstaTabVisibility; }
            set { SetProperty(ref _InstaTabVisibility, value); }
        }
        public Visibility FileIOTabVisibility
        {
            get { return _FileIOTabVisibility; }
            set { SetProperty(ref _FileIOTabVisibility, value); }
        }

        public Visibility DemoTabVisibility
        {
            get { return _DemoTabVisibility; }
            set { SetProperty(ref _DemoTabVisibility, value); }
        }

        public Lazy<UserControl> CurrentTab
        {
            get { return _CurrentTab; }
            set { SetProperty(ref _CurrentTab, value); }
        }


    }
}
