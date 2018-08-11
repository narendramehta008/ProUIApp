using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BaseUI.MainViewModel;

namespace BaseUI.FBViewModel
{
   public class FBMainPageViewModel : BindableObject
    {
        private string _UserName;
        private string _UserPassword;
        private string _SearchFriend;
        private string _LogoSource;
        private bool _LoginStatus;

        private ObservableCollection<string> _SuggestionList = new ObservableCollection<string>();

        public ObservableCollection<string> SuggestionList
        {
            get { return _SuggestionList; }
            set { SetProperty(ref _SuggestionList, value); }
        }


        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }
        public string UserPassword
        {
            get { return _UserPassword; }
            set { SetProperty(ref _UserPassword, value); }
        }
        public string SearchFriend
        {
            get { return _SearchFriend; }
            set { SetProperty(ref _SearchFriend, value); }
        }

        public string LogoSource
        {
            get { return _LogoSource; }
            set { SetProperty(ref _LogoSource, value); }
        }
        public bool LoginStatus
        {
            get { return _LoginStatus; }
            set { SetProperty(ref _LoginStatus, value); }
        }
    }
    public class FBUsersDetails : BindableObject
    {
        public string FBUserName; 
        public string FBUserPassword ;
        public string FBUserFullName ;
        public string FBUserId ;
        public string FBAccountId ;
        public string FBUserPhotoUrl ;

        private ObservableCollection<FBUsersDetails> _FriendsList = new ObservableCollection<FBUsersDetails>(); // ;

        public ObservableCollection<FBUsersDetails> FriendsList
        {
            get { return _FriendsList; }
            set { SetProperty(ref _FriendsList, value); }
        }

    }

    public class FbUrlDataBind
    {
        public string FbLoginPageGetUrl ;
        public string FbLoginPageGetHtml ;
        public string FbLoginPostHtml ;
        public string FbLoginPostUrl ;
        public string FbLoginPostData ;
        public string FbLogoutPagePostHtml ;
        public string FbLogoutPagePostData ;

        public string FbProfileUrl ;

        public string FbProfileHtml ;

        public string FbProfileImageUrl ;

        public string FbSuggestUrl ;
        public string FbSuggestKeyword ;

        public string FbSuggestGetHtml ;
        public string userUrlID ;
        public string fb_dtsg ;
        public string _spin_r ;
        public string _spin_t ;
        public string jazoest ;

        public string ClientRevision ;
        public string userUrl ;

    }
}

