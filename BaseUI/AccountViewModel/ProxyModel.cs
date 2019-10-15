using BaseLibs.Handlers.BindManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUI.AccountViewModel
{
    public class ProxyModel : BindableObject
    {
        private long _Id;
        private string _groupName;
        private string _proxyIp;
        private string _proxyPort;
        private string _proxyUsername;
        private string _proxyPassword;


        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        // used by user for login because it may use username or email
        public string GroupName
        {
            get { return _groupName; }
            set { SetProperty(ref _groupName, value); }
        }
        public string ProxyIp
        {
            get { return _proxyIp; }
            set { SetProperty(ref _proxyIp, value); }
        }
        
        public string ProxyPort
        {
            get { return _proxyPort; }
            set { SetProperty(ref _proxyPort, value); }
        }
        
        public string ProxyUsername
        {
            get { return _proxyUsername; }
            set { SetProperty(ref _proxyUsername, value); }
        }
        
        public string ProxyPassword
        {
            get { return _proxyPassword; }
            set { SetProperty(ref _proxyPassword, value); }

        }

    }
}
