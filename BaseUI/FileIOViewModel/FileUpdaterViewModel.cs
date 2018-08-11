using BaseUI.MainViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUI.FileIOViewModel
{
    public class FileUpdaterViewModel : BindableObject
    {
        private string _FilePath;
        private string _FileData;
        private bool _FilePresent = false;
        private string _Find;
        private string _Replace = "";
        private string _FileSaveAs;


        public string FilePath
        {
            get { return _FilePath; }
            set { SetProperty(ref _FilePath, value); }
        }
        public string FileData
        {
            get { return _FileData; }
            set { SetProperty(ref _FileData, value); }
        }

        public string Find
        {
            get { return _Find; }
            set { SetProperty(ref _Find, value); }
        }


        public string Replace
        {
            get { return _Replace; }
            set { SetProperty(ref _Replace, value); }
        }

        public string FileSaveAs
        {
            get { return _FileSaveAs; }
            set { SetProperty(ref _FileSaveAs, value); }
        }
    }


    public class StringBuilderWithValue
    {
        public StringBuilder sb = new StringBuilder();
        public void Append(string str)
        {
            sb.Append(str);
            Value = sb.ToString();
        }

        public string Value { get; set; }

        public void Clear()
        {
            sb.Clear();
            Value = sb.ToString();
        }

        public void AppendFormat(string format, object arg)
        {
            sb.AppendFormat(format, arg);
            Value = sb.ToString();
        }

    }
}
