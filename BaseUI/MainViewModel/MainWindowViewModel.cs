using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BaseLibs.Handlers.BindManager;
using System.Collections.ObjectModel;

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

        private string _WindowMaximize = "Maximize";//App.Current.FindResource("LangKeyMaximize").ToString();
        //private string _SelectedLanguage = App.Current.FindResource("LanguageEng").ToString();
        private Visibility _WindowMaximizeIcon = Visibility.Visible;
        private Visibility _WindowRestoreIcon = Visibility.Collapsed;
        private ObservableCollection<string> _Logger = new ObservableCollection<string>();


        private UserControl _CurrentTab;// = new Lazy<UserControl>();

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

        public UserControl CurrentTab
        {
            get { return _CurrentTab; }
            set { SetProperty(ref _CurrentTab, value); }
        }

        

       // public List<string> Languages = new List<string>() { LanguageEnums.English.ToString(), LanguageEnums.French.ToString() }; /* App.Current.FindResource("LanguageEng").ToString(),
                //App.Current.FindResource("LanguageHindi").ToString(),
               /* App.Current.FindResource("LanguageFr").ToString()*/

       

        //public string SelectedLanguage
        //{
        //    get { return _SelectedLanguage; }
        //    set { SetProperty(ref _SelectedLanguage, value); }
        //}

        
        public string WindowMaximize
        {
            get { return _WindowMaximize; }
            set { SetProperty(ref _WindowMaximize, value); }
        }
      
        public Visibility WindowMaximizeIcon
        {
            get { return _WindowMaximizeIcon; }
            set { SetProperty(ref _WindowMaximizeIcon, value); }
        }

       public Visibility WindowRestoreIcon
        {
            get { return _WindowRestoreIcon; }
            set { SetProperty(ref _WindowRestoreIcon, value); }
        }

       
        public ObservableCollection<string> Logger
        {
            get { return _Logger; }
            set { SetProperty(ref _Logger, value); }
        }
    }
}
