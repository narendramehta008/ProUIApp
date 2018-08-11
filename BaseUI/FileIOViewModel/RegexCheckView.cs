using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BaseUI.MainViewModel;

namespace BaseUI.FileIOViewModel
{
    public class RegexCheckView : BindableObject
    {
        private string _FilePath;
        private string _FileData;
        private string _RegexExpression;
        private string _GroupNumber;
        private int _Current;
        private ObservableCollection<MatchCollection> _RegexResult = new ObservableCollection<MatchCollection>();
        private ObservableCollection<string> _ListBoxResult = new ObservableCollection<string>();
        private ObservableCollection<RegexCheckView> _RegexCheckViewObj = new ObservableCollection<RegexCheckView>();

        public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                SetProperty(ref _FilePath, value);
            }
        }

        public string FileData
        {
            get
            {
                return _FileData;
            }
            set
            {
                SetProperty(ref _FileData, value);
            }
        }

        public string RegexExpression
        {
            get
            {
                return _RegexExpression;
            }
            set
            {
                SetProperty(ref _RegexExpression, value);
            }
        }

        public string GroupNumber
        {
            get
            {
                return _GroupNumber;
            }
            set
            {
                SetProperty(ref _GroupNumber, value);
            }
        }

        public int Current
        {
            get
            {
                return _Current;
            }
            set
            {
                SetProperty(ref _Current, value);
            }
        }
        public ObservableCollection<MatchCollection> RegexResult
        {
            get
            {
                return _RegexResult;
            }
            set
            {
                SetProperty(ref _RegexResult, value);
            }
        }

        public ObservableCollection<string> ListBoxResult
        {
            get { return _ListBoxResult; }
            set
            {
                SetProperty(ref _ListBoxResult, value);
            }
        }

        public ObservableCollection<RegexCheckView> RegexCheckViewObj
        {
            get { return _RegexCheckViewObj; }
            set
            {
                SetProperty(ref _RegexCheckViewObj, value);
            }
        }

        //public override string ToString()
        //{
        //    return this.Current + " : " + this.RegexResult ;
        //}

    }
}
