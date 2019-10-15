using BaseLibs.Handlers.BindManager;
using BaseUI.MainViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace BaseUI.FileIOViewModel
{
    public class FileViewerView : BindableObject
    {
        private string _FilePath;
        private bool _FilePresent = false;
        //private string _SearchFile;
        private string _SearchFilePath;
        private Dictionary<string, string> _FoldersSubfolders = new Dictionary<string, string>();
        private List<string> _FoldersList = new List<string>();
        private TreeView _FileTreeView = new TreeView();

        private string _CurrentFilePath = "";
        private string _LastFilePath = "";
        private List<string> _FoldersSubPath = new List<string>();
        private List<string> _FoldersVisited = new List<string>();
        private int _FoldersVisitedCount;
        private int _FilesVisitedCount;
        private int _FolderCurrentCount;
        private Folder _FolderView = new Folder();
        private ObservableCollection<Folders> _SimpleFolderView = new ObservableCollection<Folders>();

        private List<string> _DriveList = new List<string>();
        private string _DriveName;
        private string _SearchFileStatus;
        private string _SearchFileName;
        private string _SearchFileFullPath;
        private string _SearchFileElaspedTime;
        private List<string> _SearchVisitedFolders = new List<string>();


        public string FilePath
        {
            get { return _FilePath; }
            set { SetProperty(ref _FilePath, value); }
        }

        //public string SearchFile
        //{
        //    get { return _SearchFile; }
        //    set { SetProperty(ref _SearchFile, value); }
        //}

        public string SearchFilePath
        {
            get { return _SearchFilePath; }
            set { SetProperty(ref _SearchFilePath, value); }
        }

        public string CurrentFilePath
        {
            //_CurrentFilePath
            get { return _CurrentFilePath; }
            set { SetProperty(ref _CurrentFilePath, value); }
        }

        public string LastFilePath
        {
            get { return _LastFilePath; }
            set { SetProperty(ref _LastFilePath, value); }
        }

        public int FolderCurrentCount
        {
            get { return _FolderCurrentCount; }
            set { SetProperty(ref _FolderCurrentCount, value); }
        }

        public List<string> FoldersSubPath
        {
            get { return _FoldersSubPath; }
            set { SetProperty(ref _FoldersSubPath, value); }
        }
        ///_SimpleFolderView
        ///
        public ObservableCollection<Folders> SimpleFolderView
        {
            get { return _SimpleFolderView; }
            set { SetProperty(ref _SimpleFolderView, value); }
        }
        public int FoldersVisitedCount
        {
            get { return _FoldersVisitedCount; }
            set { SetProperty(ref _FoldersVisitedCount, value); }
        }

        public int FilesVisitedCount
        {
            get { return _FilesVisitedCount; }
            set { SetProperty(ref _FilesVisitedCount, value); }
        }
        public List<string> FoldersVisited
        {
            get { return _FoldersVisited; }
            set { SetProperty(ref _FoldersVisited, value); }
        }

        public Folder FolderView
        {
            get { return _FolderView; }
            set { SetProperty(ref _FolderView, value); }
        }

        public TreeView FileTreeView
        {
            get { return _FileTreeView; }
            set { SetProperty(ref _FileTreeView, value); }
        }

        public bool FilePresent
        {
            get { return _FilePresent; }
            set { SetProperty(ref _FilePresent, value); }
        }

        public Dictionary<string, string> FoldersSubfolders
        {
            get
            {
                return _FoldersSubfolders;
            }
            set
            {
                SetProperty(ref _FoldersSubfolders, value);
            }
        }

        public List<string> FoldersList
        {
            get
            {
                return _FoldersList;
            }
            set
            {
                SetProperty(ref _FoldersList, value);
            }
        }


        public string DriveName
        {
            get { return _DriveName; }
            set { SetProperty(ref _DriveName, value); }
        }
        public string SearchFileStatus
        {
            get { return _SearchFileStatus; }
            set { SetProperty(ref _SearchFileStatus, value); }
        }
        public string SearchFileName
        {
            get { return _SearchFileName; }
            set { SetProperty(ref _SearchFileName, value); }
        }
        public string SearchFileFullPath
        {
            get { return _SearchFileFullPath; }
            set { SetProperty(ref _SearchFileFullPath, value); }
        }

        public string SearchFileElaspedTime
        {
            get { return _SearchFileElaspedTime; }
            set { SetProperty(ref _SearchFileElaspedTime, value); }
        }

        public List<string> DriveList
        {
            get { return _DriveList; }
            set { SetProperty(ref _DriveList, value); }
        }
        public List<string> SearchVisitedFolders
        {
            get { return _SearchVisitedFolders; }
            set { SetProperty(ref _SearchVisitedFolders, value); }
        }

    }



        public class Folder
        {
            public Folder()
            {
                Files = new ObservableCollection<string>();
                Folders = new ObservableCollection<Folder>();
            }
            public string FullPath { get; set; }
            public ObservableCollection<string> Files { get; set; }
            // public string FolderLabel { get; set; }
            public ObservableCollection<Folder> Folders { get; set; }

        }


    public class Folders
    {
        public Folders()
        {
            this.ListFiles = new ObservableCollection<FileData>();
        }

        public string FolderPath { get; set; }

        public ObservableCollection<FileData> ListFiles { get; set; }
    }

    public class FileData
    {
        public string FileName { get; set; }

        public int FileSize { get; set; }
    }
}
