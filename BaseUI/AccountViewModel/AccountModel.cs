using BaseLibs.Handlers.BindManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUI.AccountViewModel
{
    public class AccountModel : BindableObject
    {

        private long _Id;
        private string _LoginUsername;
        private string _Username;
        private string _Email;
        private string _Password;
        private string _Status;
        private string _FullName;
        private string _ProfilePicUrl;
        private string _SiteUrl;
        private string _PhoneNumber;
        private string _Bio;
        private string _OtherDetails;
        private string _Session;
        private string _CachePath;
        private ProxyModel _proxyModel;


        [Key]
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        // used by user for login because it may use username or email
  
        public string LoginUsername
        {
            get { return _LoginUsername; }
            set { SetProperty(ref _LoginUsername, value); }
        }
        
        public string UserName
        {
            get { return _Username; }
            set { SetProperty(ref _Username, value); }
        }
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }
        
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }

        }
        public string Status
        {
            get { return _Status; }
            set { SetProperty(ref _Status, value); }
        }
        
        public string FullName
        {
            get { return _FullName; }
            set { SetProperty(ref _FullName, value); }
        }

        

        public string ProfilePicUrl
        {
            get { return _ProfilePicUrl; }
            set { SetProperty(ref _ProfilePicUrl, value); }
        }
        
        public string SiteNameUrl
        {
            get { return _SiteUrl; }
            set { SetProperty(ref _SiteUrl, value); }
        }

    
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { SetProperty(ref _PhoneNumber, value); }
        }
        
        public string Bio
        {
            get { return _Bio; }
            set { SetProperty(ref _Bio, value); }
        }
        
        public string OtherDetails
        {
            get { return _OtherDetails; }
            set { SetProperty(ref _OtherDetails, value); }
        }
        
        public string Session
        {
            get { return _Session; }
            set { SetProperty(ref _Session, value); }
        }
        public string CachePath
        {
            get { return _CachePath; }
            set { SetProperty(ref _CachePath, value); }
        }
     
        public ProxyModel ProxyModel
        {
            get { return _proxyModel; }
            set { SetProperty(ref _proxyModel, value); }
        }

    }

    public class AccountStatus
    {
        public const string Success = "Success";
        public const string Failed = "Failed";
    }

}
