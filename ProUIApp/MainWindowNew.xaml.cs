using BaseLibs.Handlers.LoggerConfigPack;
using BaseUI.MainViewModel;
using MaterialDesignThemes.Wpf;
using ProUIApp.View.AccountView;
using ProUIApp.View.ContentView;
using ProUIApp.View.DemoView;
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
using System.Windows.Shapes;

namespace ProUIApp
{
    /// <summary>
    /// Interaction logic for MainWindowNew.xaml
    /// </summary>
    public partial class MainWindowNew : Window
    {
        public MainWindowNew()
        {
            InitializeComponent();
            DataContext = MainWindowViewModel;
            MainWindowViewModel.ListTabItemTemplate = new List<TabItemTemplate>()
            {
                new TabItemTemplate(){ IconType = PackIconKind.Account,TabName="Account",TabTemplate=new Lazy<UserControl>(AccountContentPage.getObj)},
                new TabItemTemplate(){ IconType = PackIconKind.File,TabName="FileIO",TabTemplate=new Lazy<UserControl>(FileIOContentPage.getObj)},
                new TabItemTemplate(){ IconType = PackIconKind.Facebook,TabName="FaceBook",TabTemplate=new Lazy<UserControl>(FBContentPage.getObj)},
                new TabItemTemplate(){ IconType = PackIconKind.Instagram,TabName="Instagram",TabTemplate=new Lazy<UserControl>(InstaContentPage.getObj)},
                new TabItemTemplate(){ IconType = PackIconKind.Twitter,TabName="Twitter",TabTemplate=new Lazy<UserControl>(TDContentPage.getObj)},
                new TabItemTemplate(){ IconType = PackIconKind.Check,TabName="Demo",TabTemplate=new Lazy<UserControl>(SimpleMaterial.GetObj)},
            };
        }
        MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                //Logger.Log.Error(ex.ToString());
            }
        }
        private void WindowMaximize_Click(object sender, RoutedEventArgs e)
        {
            #region Window Maximize
            try
            {
                if (MainWindowViewModel.WindowMaximize.Equals("Maximize"))
                {
                    MainWindowViewModel.WindowMaximizeIcon = Visibility.Collapsed;
                    MainWindowViewModel.WindowRestoreIcon = Visibility.Visible;
                    WindowState = WindowState.Maximized;
                    MainWindowViewModel.WindowMaximize = "Restore";
                }
                else
                {
                    MainWindowViewModel.WindowMaximizeIcon = Visibility.Visible;
                    MainWindowViewModel.WindowRestoreIcon = Visibility.Collapsed;
                    WindowState = WindowState.Normal;
                    MainWindowViewModel.WindowMaximize = "Maximize";
                }

            }
            catch (Exception ex)
            {
                //Logger.Log.Error(ex.ToString());
            }
            #endregion
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            string winClose = "No";
            winClose = FirstFloor.ModernUI.Windows.Controls.ModernDialog.ShowMessage("Are you really want to exit?", "UniWeb", MessageBoxButton.YesNo).ToString();
            if (winClose.Equals("Yes"))
                   this.Close();
            //try
            //{
            //    string winClose = "No";
            //    switch (MainWindowViewModel.SelectedLanguage)
            //    {
            //        case "English":
            //            {
            //                winClose = ModernDialog.ShowMessage("Are you really want to exit?", "UniWeb", MessageBoxButton.YesNo).ToString();
            //            }
            //            break;

                //        case "Hindi":
                //            {
                //                winClose = ModernDialog.ShowMessage("क्या आप वास्तव में बाहर निकलना चाहते हैं ? ", "UniWeb", MessageBoxButton.YesNo).ToString();
                //            }
                //            break;
                //        case "French":
                //            {
                //                winClose = ModernDialog.ShowMessage(" vous vraiment quitter ? ", "UniWeb", MessageBoxButton.YesNo).ToString();
                //            }
                //            break;
                //    }
                //    if (winClose.Equals("Yes"))
                //        this.Close();
                //}
                //catch (Exception ex)
                //{
                //    //Logger.Log.Error(ex.ToString());
                //}
        }

        private void Languages_Selected(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    App.ChangeUILanguage(MainWindowViewModel.SelectedLanguage);
            //    DataContext = MainWindowViewModel;
            //    Languages.ItemsSource = MainWindowViewModel.Languages;
            //}
            //catch (Exception ex)
            //{
            //    //Logger.Log.Error(ex.ToString());
            //}
        }

        private void ListViewLogger_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (GridFooter.Height.Value == 50)
                    GridFooter.Height = new GridLength(250);
                else
                    GridFooter.Height = new GridLength(50);
            }
            catch (Exception ex)
            {
                ListViewLogger.Dispatcher.Invoke(new Action(delegate
                {
                    if (GridFooter.Height.Value == 150)
                        GridFooter.Height = new GridLength(150);
                    else
                        GridFooter.Height = new GridLength(50);
                }));
                Logger.Log.Error(ex.ToString());
            }
        }

        private void AddToLogger(string message)
        {
            try
            {
                ListViewLogger.Dispatcher.Invoke(new Action(delegate
                {
                    MainWindowViewModel.Logger.Insert(0, $"{DateTime.Now.ToString("yyyy/dd/MM HH:ss => ")} {message}");
                }));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

    }
}
