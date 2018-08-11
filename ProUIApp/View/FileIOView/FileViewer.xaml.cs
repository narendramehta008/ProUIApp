using BaseUI.FileIOViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.Windows.Input;
using System.Windows.Media;


namespace ProUIApp.View.FileIOView
{
    /// <summary>
    /// Interaction logic for FileViewer.xaml
    /// </summary>
    public partial class FileViewer : UserControl
    {
        FileViewerView fileViewModel = new FileViewerView();
        Stopwatch stopWatch = new Stopwatch();

        public FileViewer()
        {
            InitializeComponent();
            InitializeValues();
            DataContext = fileViewModel;
        }

        private static FileViewer obj;
        private static bool Stop = false;

        public static FileViewer getObj()
        {
            return obj ?? (obj = new FileViewer());
        }

        private void InitializeValues()
        {
            try
            {
                fileViewModel.DriveList = DriveInfo.GetDrives().Select(drive => drive.Name.Replace(":\\", "")).ToList();
                ComboBoxDrive.Dispatcher.Invoke(new Action(delegate { ComboBoxDrive.SelectedItem = fileViewModel.DriveList[0]; }));

            }
            catch (Exception ex) { }
        }
        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Thread th = new Thread(ButtonBrowse_Click);
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex) { }
        }

        private void ButtonBrowse_Click()
        {
            try
            {

                OpenFileDialog opf = new OpenFileDialog();

                if (opf.ShowDialog() == true)
                {
                    fileViewModel.FilePath = opf.FileName;
                    Thread th = new Thread(() => getAllFiles(fileViewModel.FilePath, "AddToTreeView"));
                    th.IsBackground = true;
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
            catch (Exception ex) { }
        }


        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Stop = true;
                stopWatch.Stop();
            }
            catch (Exception ex) { }
        }

        private void ButtonSearchFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(fileViewModel.SearchFileName.Trim()))
                    return;

                Thread th = new Thread(() => getAllFiles(fileViewModel.FilePath, "SearchFile"));
                th.IsBackground = true;
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            catch { }
        }

        public async void getAllFiles(string filePath, string callType)
        {
            try
            {
                Stop = false;
                fileViewModel.FoldersVisitedCount = 0;
                fileViewModel.FilesVisitedCount = 0;
                fileViewModel.FoldersVisited.Clear();
                fileViewModel.SearchVisitedFolders.Clear();
                fileViewModel.SearchFileFullPath = "";
            }
            catch (Exception ex)
            {
            }

            try
            {
                if (callType.Equals("AddToTreeView"))
                {
                    #region Add Folder and Files to Treeview

                    try
                    {
                        trvFolders.Dispatcher.Invoke(new Action(delegate { trvFolders.ItemsSource = fileViewModel.SimpleFolderView; }));
                        fileViewModel.FoldersSubPath = fileViewModel.FilePath.Split('\\').ToList();
                        Folder folder = new Folder();

                        stopWatch.Start();
                        await Task.Factory.StartNew(() => AddFilesToFolder(ref folder, filePath));      // first letting all values then assign to folder view

                        //AddFilesToFolder(ref folder, filePath);

                        fileViewModel.FolderView.Folders.Add(folder);
                        stopWatch.Stop();

                        fileViewModel.SearchFileElaspedTime = stopWatch.ElapsedTicks.ToString();
                    }
                    catch (Exception ex) { }

                    #endregion
                }
                else if (callType.Equals("SearchFile"))
                {
                    Folder folder = new Folder();
                    ComboBoxDrive.Dispatcher.Invoke(new Action(delegate { fileViewModel.DriveName = ComboBoxDrive.Text.ToString() + ":\\"; }));
                    await Task.Factory.StartNew(() => SearchFileStart(folder, fileViewModel.DriveName));
                    if (string.IsNullOrEmpty(fileViewModel.SearchFileFullPath))
                        fileViewModel.SearchFileStatus = "Not Found";
                }
            }
            catch (Exception ex)
            {
            }

        }

        /// <summary>
        /// Getting all the files and folders adding them to their order
        /// </summary>
        /// <param name="filePath"></param>
        public void AddFilesToFolder(ref Folder fold, string path)
        {
            if (Stop)
                return;

            List<string> filePaths = new List<string>();
            List<FileInfo> AllFiles = new List<FileInfo>();
            List<FileInfo> FolderFiles = new List<FileInfo>();
            List<DirectoryInfo> AllFolders = new List<DirectoryInfo>();
            List<DirectoryInfo> FolderFolders = new List<DirectoryInfo>();



            Folder folder = new Folder();
            filePaths = path.Split('\\').ToList();
            filePaths = filePaths.Where(fl => string.IsNullOrEmpty(fl.Trim()) == false).ToList();
            int currentPathCount = 0;
            string lastPath = "";

            try
            {
                while (currentPathCount < filePaths.Count)
                {

                    if (string.IsNullOrEmpty(lastPath.Trim()))
                    {
                        lastPath = filePaths[currentPathCount] + "\\";
                    }
                    else if (lastPath[lastPath.Length - 1].Equals('\\'))
                    {
                        lastPath += filePaths[currentPathCount];
                    }
                    else
                    {
                        lastPath += "\\" + filePaths[currentPathCount];
                    }

                    ++currentPathCount;

                    if (!fileViewModel.FoldersVisited.Contains(lastPath))
                    {
                        fileViewModel.FoldersVisited.Add(lastPath);
                        fold.FullPath = lastPath;
                    }
                    else continue;

                    ++fileViewModel.FoldersVisitedCount;

                    try
                    {
                        FolderFiles = new DirectoryInfo(lastPath).GetFiles().ToList();
                        FolderFolders = new DirectoryInfo(lastPath).GetDirectories().ToList();
                    }
                    catch (Exception ex)
                    {
                    }

                    foreach (DirectoryInfo dirInfo in FolderFolders)
                    {
                        if (dirInfo.FullName.Contains("$RECYCLE.BIN"))
                            continue;

                        if (Stop)
                            return;

                        Folder tempFolder = new Folder();
                        AddFilesToFolder(ref tempFolder, dirInfo.FullName);
                        tempFolder.FullPath = dirInfo.FullName;
                        folder.Folders.Add(tempFolder);
                    }

                    /// Adding All Folder having files
                    /// 
                    if (FolderFiles.Count > 0)
                    {
                        Folders objFolders = new Folders();
                        objFolders.FolderPath = lastPath;
                        FolderFiles.ForEach(file => { objFolders.ListFiles.Add(new FileData { FileName = file.Name, FileSize = (int)(file.Length / 1024) }); });
                        trvFolders.Dispatcher.Invoke(new Action(delegate { fileViewModel.SimpleFolderView.Add(objFolders); }));
                    }

                    //fileViewModel.SimpleFolderView

                    foreach (FileInfo fileInfo in FolderFiles)
                    {
                        try { TextBoxVisitedFilesCount.Dispatcher.Invoke(new Action(delegate { ++fileViewModel.FilesVisitedCount; })); } catch { }
                        folder.Files.Add(fileInfo.FullName.Substring(fileInfo.FullName.LastIndexOf('\\') + 1));

                    }
                }

            }
            catch { }
            finally
            {
                fold.Folders.Add(folder);
            }
        }

        public void SearchFileStart(Folder fold, string path)
        {
            if (Stop)
                return;

            List<string> filePaths = new List<string>();
            List<FileInfo> AllFiles = new List<FileInfo>();
            List<FileInfo> FolderFiles = new List<FileInfo>();
            List<DirectoryInfo> AllFolders = new List<DirectoryInfo>();
            List<DirectoryInfo> FolderFolders = new List<DirectoryInfo>();



            Folder folder = new Folder();
            filePaths = path.Split('\\').ToList();
            filePaths = filePaths.Where(fl => string.IsNullOrEmpty(fl.Trim()) == false).ToList();
            int currentPathCount = 0;
            string lastPath = "";

            try
            {
                while (currentPathCount < filePaths.Count)
                {

                    if (string.IsNullOrEmpty(lastPath.Trim()))
                    {
                        lastPath = filePaths[currentPathCount] + "\\";
                    }
                    else if (lastPath[lastPath.Length - 1].Equals('\\'))
                    {
                        lastPath += filePaths[currentPathCount];
                    }
                    else
                    {
                        lastPath += "\\" + filePaths[currentPathCount];
                    }

                    ++currentPathCount;

                    if (!fileViewModel.SearchVisitedFolders.Contains(lastPath))
                    {
                        fileViewModel.SearchVisitedFolders.Add(lastPath);
                        fold.FullPath = lastPath;
                    }
                    else continue;

                    ++fileViewModel.FoldersVisitedCount;

                    try
                    {
                        FolderFiles = new DirectoryInfo(lastPath).GetFiles().ToList();
                        FolderFolders = new DirectoryInfo(lastPath).GetDirectories().ToList();
                    }
                    catch (Exception ex)
                    {
                    }

                    foreach (FileInfo fileInfo in FolderFiles)
                    {
                        ++fileViewModel.FilesVisitedCount;
                        if (fileInfo.Name.ToLower().Contains(fileViewModel.SearchFileName.ToLower()))
                        {
                            fileViewModel.SearchFileFullPath = fileInfo.FullName;
                            Stop = true;
                            break;
                        }
                    }

                    foreach (DirectoryInfo dirInfo in FolderFolders)
                    {
                        if (dirInfo.FullName.Contains("$RECYCLE.BIN"))
                            continue;

                        if (Stop)
                            return;

                        Folder tempFolder = new Folder();
                        SearchFileStart(tempFolder, dirInfo.FullName);
                        tempFolder.FullPath = dirInfo.FullName;
                        //folder.Folders.Add(tempFolder);
                    }
                }

            }
            catch { }
        }
        public void ShowVisualTree(DependencyObject element)
        {
            // Clear the tree.
            //GridTextView.Children.Clear();
            // Start processing elements, begin at the root.
            ProcessElement(element, null);
        }
        private void ProcessElement(DependencyObject element, TreeViewItem previousItem)
        {
            // Create a TreeViewItem for the current element.
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            item.IsExpanded = true;
            // Check whether this item should be added to the root of the tree
            //(if it's the first item), or nested under another item.
            if (previousItem == null)
            {
                //  GridTextView.Children.Add(item);
                // treeElements.Items.Add(item);
            }
            else
            {
                previousItem.Items.Add(item);
            }
            // Check whether this element contains other elements.
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                // Process each contained element recursively.
                ProcessElement(VisualTreeHelper.GetChild(element, i), item);
            }
        }
    }
}
