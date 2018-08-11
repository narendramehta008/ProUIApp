//using BaseProject.Handlers;
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
               DataContext = mainWindowViewModel;
               mainWindowViewModel.CurrentTab = new Lazy<UserControl>(AccountContentPage.getObj);
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
                        mainWindowViewModel.CurrentTab = new Lazy<UserControl>(AccountContentPage.getObj);
                        break;

                    case "InstagramTab":
                        mainWindowViewModel.CurrentTab = new Lazy<UserControl>(InstaContentPage.getObj);
                        break;

                    case "FacebookTab":
                        mainWindowViewModel.CurrentTab = new Lazy<UserControl>(FBContentPage.getObj);
                        break;
                    //case "TwitterTab":
                    //    GridMain.DataContext = TwitterTab.getObj();
                    //    break;
                    case "PinterestTab":
                        mainWindowViewModel.CurrentTab = new Lazy<UserControl>(PinContentPage.getObj);
                        break;

                    case "FileIOTab":
                        mainWindowViewModel.CurrentTab = new Lazy<UserControl>(FileIOContentPage.getObj);
                        break;

                    case "DemoTab":
                        mainWindowViewModel.CurrentTab = new Lazy<UserControl>(DemoContentPage.getObj);
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
    }
}
