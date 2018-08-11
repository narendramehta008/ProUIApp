using BaseUI.FileIOViewModel;
using Microsoft.Win32;
using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for FileUpdater.xaml
    /// </summary>
    public partial class FileUpdater : UserControl
    {
       static FileUpdaterViewModel fileUpdateViewModel = new FileUpdaterViewModel();
        public FileUpdater()
        {
            InitializeComponent();
            DataContext = fileUpdateViewModel;
        }



        private static FileUpdater obj;

        public static FileUpdater getObj()
        {
            if (obj == null)
                return obj = new FileUpdater();
            return obj;
        }

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Thread th = new Thread(ButtonBrowse_Click);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            catch { }
        }

        private void ButtonBrowse_Click()
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "txt files (*.txt)|*.txt|html files (*.html)|*.html|All files (*.*)|*.*";
                bool opfResp = false;
                if (opf.ShowDialog() == true)
                    opfResp = true;

                if (opfResp)
                {

                    fileUpdateViewModel.FilePath = opf.FileName;
                    string tempData = "";
                    if (!(opf.FileName.Contains(".zip") | opf.FileName.Contains(".rar")))
                        tempData = new StreamReader(fileUpdateViewModel.FilePath).ReadToEnd();

                    try { this.Dispatcher.Invoke(new Action(delegate { fileUpdateViewModel.FileData = tempData; })); } catch (Exception ex) { }
                    // fileUpdateViewModel.FileData.Append(tempData)  ;
                }
            }
            catch (Exception ex) { }
        }

        private void ButtonSaveAs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|html files (*.html)|*.html|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, fileUpdateViewModel.FileData);
                    //string filePath = opf.FileName.Substring(0, opf.FileName.LastIndexOf("\\") + 1);
                    //string format = ".txt";

                    //if(! string.IsNullOrEmpty(fileUpdateViewModel.FilePath.Trim()))
                    //    format=fileUpdateViewModel.FilePath.Substring(fileUpdateViewModel.FilePath.LastIndexOf("."));

                    //using (StreamWriter  sr=new StreamWriter(filePath+DateTime.Now.Ticks+format))
                    //{
                    //    sr.WriteLine(fileUpdateViewModel.FileData);
                    //}
                }
            }
            catch { }
        }

        private void ButtonReplace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tempData = "";
                string tempFind = fileUpdateViewModel.Find.ToString().Replace("(", @"\(").Replace(")", @"\)").Replace("[", @"\[").Replace("]", @"\]");
                tempData = Regex.Replace(fileUpdateViewModel.FileData.ToString(), tempFind, fileUpdateViewModel.Replace);
                // tempData = fileUpdateViewModel.FileData.ToString().Replace(tempFind, fileUpdateViewModel.Replace);
                fileUpdateViewModel.FileData = "";
                Task.Factory.StartNew(() => Data(tempData));
            }
            catch (Exception ex) { }
        }


        private async void Data(string fileData)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileData.Trim()))
                {
                    fileUpdateViewModel.FileData = fileData; //new StringReader(fileData).ReadToEndAsync();
                }
            }
            catch (Exception ex) { }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fileUpdateViewModel.FileData = "";
            }
            catch (Exception ex) { }
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tempData = new StreamReader(fileUpdateViewModel.FilePath).ReadToEnd();
                fileUpdateViewModel.FileData = "";
                Task.Factory.StartNew(() => Data(tempData));
            }
            catch (Exception ex) { }
        }

        private void ButtonExtract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rarFilePath = fileUpdateViewModel.FilePath;
                string _password = "test";
                string baseDirectory = rarFilePath.Substring(0,rarFilePath.LastIndexOf('\\')+1);
                using (Stream stream = File.OpenRead(rarFilePath))
                using (var reader = ReaderFactory.Open(stream, new ReaderOptions()
                {
                    Password = _password,
                    LookForHeader = true
                }))
                {
                    while (reader.MoveToNextEntry())
                    {
                        if (!reader.Entry.IsDirectory)
                        {
                            Console.WriteLine(reader.Entry.Key);
                            string fileDestPath = baseDirectory + System.IO.Path.GetFileNameWithoutExtension(rarFilePath);

                            
                            

                            reader.WriteEntryToDirectory(fileDestPath);

                            /*, 
                                new ExtractionOptions()
                            {
                                ExtractFullPath = true,
                                Overwrite = true
                            }*/

                        }
                    }
                }
            }
            catch (Exception Ex)
            {

            }

        }

       

    }
}
