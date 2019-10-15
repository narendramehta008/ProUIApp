
using BaseLibs.Handlers.BindManager;
using BaseUI.MainViewModel;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BaseUI.FileIOViewModel
{
    public class ImageViewerViewModel : BindableObject
    {
        private string _FilePath;
        private string _CurrentImage;
        private bool _DisableSimpleImageList;
        private ObservableCollection<FileInfo> _ImageData = new ObservableCollection<FileInfo>();

        //public IInterTabClient InterTabClient { get; set; }

        public ImageViewerViewModel()
        {
            //InterTabClient = new ImageViewerInterTabClient();
        }

        public string FilePath
        {
            get { return _FilePath; }
            set { SetProperty(ref _FilePath, value); }
        }
        public string CurrentImage
        {
            get { return _CurrentImage; }
            set { SetProperty(ref _CurrentImage, value); }
        }

        public bool DisableSimpleImageList
        {
            get { return _DisableSimpleImageList; }
            set { SetProperty(ref _DisableSimpleImageList, value); }
        }


        public ObservableCollection<FileInfo> ImageData
        {
            get { return _ImageData; }
            set { SetProperty(ref _ImageData, value); }
        }
    }
}

