using BaseUI.FileIOViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProUIApp.View.FileIOView
{
    /// <summary>
    /// Interaction logic for ImageViewer.xaml
    /// </summary>
    public partial class ImageViewer : UserControl
    {
        ImageViewerViewModel imageViewModel = new ImageViewerViewModel();
        public ImageViewer()
        {
            InitializeComponent();
            DataContext = imageViewModel;
        }

        private static ImageViewer obj;

        public static ImageViewer getObj()
        {
            if (obj == null)
                return obj = new ImageViewer();
            return obj;
        }

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();

                if (opf.ShowDialog() == true)
                {
                    imageViewModel.FilePath = opf.FileName.Substring(0, opf.FileName.LastIndexOf("\\"));
                    Task.Factory.StartNew(() => ButtonBrowse_Click());
                }
            }
            catch (Exception ex) { }

        }

        private void ButtonBrowse_Click()
        {
            try
            {
                // ListBoxImageList.ItemsSource = imageViewModel.ImageData;
                List<FileInfo> listFiles = new DirectoryInfo(imageViewModel.FilePath).GetFiles("*.*", SearchOption.TopDirectoryOnly).ToList();

                

                foreach (FileInfo fileInfo in listFiles)
                {
                    Thread.Sleep(100);
                    if ((fileInfo.Name.Contains(".png") | fileInfo.Name.Contains(".jpg") | fileInfo.Name.Contains(".gif")) && (!imageViewModel.ImageData.Any(file => file.Name == fileInfo.Name)))
                        this.Dispatcher.Invoke(new Action(delegate { imageViewModel.ImageData.Add(fileInfo); }));
                }
            }
            catch (Exception ex) { }
        }

        private void MenuItemImageDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentImage = (MenuItem)sender;
                FileInfo imageInfo = CurrentImage.DataContext as FileInfo;

                this.Dispatcher.Invoke(new Action(delegate { imageViewModel.ImageData.Remove(imageInfo); }));



            }
            catch (Exception ex) { }
        }

        private void CheckBoxDisableSimpleImageList_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                GroupBoxImageList.Visibility = Visibility.Collapsed;
                if (imageViewModel.DisableSimpleImageList)
                {
                    this.Dispatcher.Invoke(new Action(delegate { ListBoxImageList.ItemsSource = ""; }));

                }
            }
            catch { }
        }

        private void CheckBoxDisableSimpleImageList_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                GroupBoxImageList.Visibility = Visibility.Visible;
                if (imageViewModel.DisableSimpleImageList)
                {
                    this.Dispatcher.Invoke(new Action(delegate { ListBoxImageList.ItemsSource = imageViewModel.ImageData; }));

                }
            }
            catch { }
        }
    }
}
