//using BaseProject.Handlers;
using BaseLibs.EntityModel.CodeFirstApproach.CodeFirstConfiguration;
using BaseLibs.Handlers.ExceptionConfigPack;
using BaseLibs.Handlers.FileHandlers;
using BaseLibs.Handlers.LoggerConfigPack;
using BaseLibs.Models.DemoModels;
using BaseUI.MainViewModel;
using FirstFloor.ModernUI.Windows.Controls;
using MainProj;
using ProUIApp.View.ContentView;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProUIApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void InfoLogger(string messge);
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            InitializeValues();
        }

        private void InitializeValues()
        {
            try
            {
                Logger.InfoLogger += AddToInfoLogger;
                //PathMapper.DBPathHandler();
                //DbContextMapper dbContextMapper = new DbContextMapper();
                //DbHandler dbHandler = new DbHandler(dbContextMapper.GetDBContext());
                //dbHandler.AddData(new DemoModelOne() { ID = 1, Name = "one"/*, ListData = new List<string>() { "one", "two" }*/ });
                // var demo = AccountContentPage.getObj();
                mainWindowViewModel.CurrentTab = AccountContentPage.getObj(); //new Lazy<UserControl>(()=>AccountContentPage.getObj());

                // CopyFiles.Copydata();
                Class1 a = new Class1();
                a.chal();

            }
            catch (Exception ex) { }
        }

    
      
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string tabSwitch = ((ListViewItem)((ListView)sender).SelectedItem).Name;

                switch (tabSwitch)
                {
                    case "AllAccountTab":
                        mainWindowViewModel.CurrentTab = AccountContentPage.getObj();//new Lazy<UserControl>(AccountContentPage.getObj);
                        break;

                    case "InstagramTab":
                        mainWindowViewModel.CurrentTab = InstaContentPage.getObj();//new Lazy<UserControl>(InstaContentPage.getObj);
                        break;

                    case "FacebookTab":
                        mainWindowViewModel.CurrentTab = FBContentPage.getObj();// new Lazy<UserControl>(FBContentPage.getObj);
                        break;
                    //case "TwitterTab":
                    //    GridMain.DataContext = TwitterTab.getObj();
                    //    break;
                    case "PinterestTab":
                        mainWindowViewModel.CurrentTab = PinContentPage.getObj();// new Lazy<UserControl>(PinContentPage.getObj);
                        break;

                    case "FileIOTab":
                        mainWindowViewModel.CurrentTab = FileIOContentPage.getObj();//new Lazy<UserControl>(()=>FileIOContentPage.getObj());
                        break;

                    case "DemoTab":
                        mainWindowViewModel.CurrentTab = DemoContentPage.getObj();// new Lazy<UserControl>(()=>DemoContentPage.getObj());
                        break;

                }
            }
            catch { }
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           try
            {
                var winClose = ModernDialog.ShowMessage("Are you really want to exit?", "ProUI", MessageBoxButton.YesNo).ToString();
                if (winClose.Equals("Yes"))
                    this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void AddToInfoLogger(string message)
        {
            try
            {
                ListViewInfoLogger.Dispatcher.Invoke(new Action(delegate
                {
                    ListViewInfoLogger.Items.Insert(0, $"{DateTime.Now.ToString("yyyy/dd/MM HH:ss => ")} {message}");
                }));
            }
            catch (Exception ex)
            {
                ex.ErrorLog(ex.ToString());
            }
        }
    }
}
