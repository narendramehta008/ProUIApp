
using CefSharp;
using System;
using System.Collections.Generic;
using System.Windows;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Newtonsoft.Json;
using BaseUI.AccountViewModel;

namespace ProUIApp.View.AccountView
{
    /// <summary>
    /// Interaction logic for EmbedBrowser.xaml
    /// </summary>
    public partial class EmbedBrowser
    {
        private string path = @"C:\AllWebFetcher";
        private readonly object _cefLock = new object();


        public EmbedBrowser()
        {
            InitializeComponent();
        }

        private void ButtonForward_OnClick(object sender, RoutedEventArgs e)
        {
            Browser.Forward();
        }

        private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
        {
            Browser.Back();
        }

        private void ButtonRefresh_OnClick(object sender, RoutedEventArgs e)
        {
            Browser.Load(UrlBar.Text);
        }



        public EmbedBrowser(AccountModel accountModel) : this()
        {

            AccountModel = accountModel;
            Browser.RequestContext = new CefSharp.RequestContext(new RequestContextSettings
            {
                CachePath = $"{path}\\{accountModel.UserName}"
            });

            Browser.MenuHandler = new MenuHandler();
            Browser.RequestHandler = new RequestHandlerCustom(this);
            var url = GetNetworksHomeUrl();
            Browser.Address = url;
            // Browser.Load(url);
            UrlBar.Text = url;
            Browser.IsBrowserInitializedChanged += LoadSettings;

        }

        private AccountModel _accountModel;
        public AccountModel AccountModel
        {
            get
            {
                return _accountModel;
            }
            set
            {
                _accountModel = value;
                OnPropertyChanged(nameof(AccountModel));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadSettings(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (!Browser.IsBrowserInitialized)
                return;
            try
            {
                Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(AccountModel.ProxyModel.ProxyUsername) &&
                            !string.IsNullOrEmpty(AccountModel.ProxyModel.ProxyPassword))
                            Browser.RequestHandler = new ProxyRequestHandler(
                                AccountModel.ProxyModel.ProxyUsername,
                                AccountModel.ProxyModel.ProxyPassword, this);

                        // get the proxyip from objDominatorAccountModel object
                        var proxyIp = AccountModel.ProxyModel.ProxyIp;

                        // get the proxyport from objDominatorAccountModel object
                        var proxyPort = AccountModel.ProxyModel.ProxyPort;

                        // get the current browser request context
                        var requestContext = Browser.GetBrowser().GetHost().RequestContext;

                        if (!string.IsNullOrEmpty(proxyIp) && !string.IsNullOrEmpty(proxyPort))
                        {
                            // declare the dictionary for passing proxy ip and proxy port
                            var dictProxyIpPort = new Dictionary<string, object>
                            {
                                {"mode", "fixed_servers"},
                                {"server", "" + proxyIp + ":" + proxyPort + ""}
                            };

                            string error;

                            requestContext.SetPreference("proxy", dictProxyIpPort, out error);
                        }
                        else
                        {
                            var dictProxyIpPort = new Dictionary<string, object> { { "mode", "direct" } };


                            string error;

                            requestContext.SetPreference("proxy", dictProxyIpPort, out error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            var homePage = GetNetworksHomeUrl();
            Browser.Load(homePage);

            Browser.LoadingStateChanged += BrowserOnFrameLoadEnd;
        }

        private void BrowserOnFrameLoadEnd(object sender, LoadingStateChangedEventArgs loadingStateChangedEventArgs)
        {
            try
            {
                bool isLoaded = false;
                Dispatcher.Invoke(() =>
                {
                    try
                    {
                        isLoaded = Browser.IsLoaded;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                });

                if (!isLoaded) return;

                if (!string.IsNullOrEmpty(AccountModel.UserName) &&
                    !string.IsNullOrEmpty(AccountModel.Password))
                {
                    Browser.GetSourceAsync().ContinueWith(taskHtml =>
                    {
                        try
                        {
                            var html = taskHtml.Result;
                            if (html != null)
                            {
                                if (!string.IsNullOrEmpty(html))
                                    LogIn();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                        }
                    });


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        internal void MouseClick(int key, int value, int delayAfter)
        {
            throw new NotImplementedException();
        }

        private bool _isRunning;

        private void LogIn()
        {
            lock (_cefLock)
            {

                if (_isRunning)
                    return;

            }
            _isRunning = true;
            Thread.Sleep(5000);
            Browser.ExecuteScriptAsync("document.getElementById('fm-login-id').value= '" + _accountModel.UserName + "'");
            Thread.Sleep(10000);
            Browser.ExecuteScriptAsync("document.getElementById('fm-login-password').value= '" + _accountModel.Password + "'");
            Thread.Sleep(5000);
            Browser.ExecuteScriptAsync("document.getElementById('fm-login-submit').click()");
            Thread.Sleep(10000);

            SaveCookie(AccountModel);


            if (string.IsNullOrEmpty(TargetUrl))
            {

                TargetUrl = "https://www.linkedin.com/";

                var checkResult = GetLoggedInPageSource();

                AccountModel.Status
                    = checkResult.Contains("User") ? AccountStatus.Success : AccountStatus.Failed;

               
                return;
            }
            var result = GetLoggedInPageSource();

            if (!string.IsNullOrEmpty(result) && result.Contains("profile_icon"))
            {
                LoadPostPage(true);
            }
        }


        private void SaveCookie(AccountModel AccountModel)
        {
            if (!_isRunning) return;

            try
            {
                var lstCookies = Browser.RequestContext.GetDefaultCookieManager(new TaskCompletionCallback())
                    .VisitAllCookiesAsync().Result;

                var lstCookieDetails = new HashSet<CookieDetails>();

                foreach (var eachCookie in lstCookies)
                {
                    var cookie = new CookieDetails
                    {
                        Name = eachCookie.Name,
                        Value = eachCookie.Value,
                        Domain = eachCookie.Domain
                    };

                    lstCookieDetails.Add(cookie);
                }

                if (lstCookieDetails.Count == 0)
                    return;

                AccountModel.Session = JsonConvert.SerializeObject(lstCookieDetails);
                //Inserting dataBase
                UpdateCookie(AccountModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void SetCookie()
        {
            try
            {
                var cookies = JsonConvert.DeserializeObject<List<Cookie>>(AccountModel.Session);

                var cookieManager = Browser.RequestContext.GetDefaultCookieManager(new TaskCompletionCallback());
                foreach (var cookie in cookies)
                {
                    cookieManager.SetCookie("https://www.linkedin.com/",cookie);
                }

            }
            catch (Exception ex)
            {
            }
        }
        public void UpdateCookie(AccountModel AccountModel)
        {

            //var modelClassConverter = new ModelClassConverter();

            //var accountDetail = modelClassConverter.AccountDetail(AccountModel);

            //var databaseHandler = new DatabaseHandler();
            //var accountDetails = databaseHandler.GetSingleData<AccountDetail>
            //    (x => x.UserName == AccountModel.UserName);
            //accountDetails.Cookies = accountDetail.Cookies;

            //databaseHandler.UpdateData(accountDetails);
        }


        private void LoadPostPage(bool isLoggedIn)
        {
            if (isLoggedIn)
            {
                Browser.Load(TargetUrl);
                Browser.LoadingStateChanged -= BrowserOnFrameLoadEnd;
            }
        }

        private string GetLoggedInPageSource()
        {
            if (!string.IsNullOrEmpty(TargetUrl) && TargetUrl != "Not Published Yet")
            {
                var sourceAsync = Browser.GetSourceAsync();
                return sourceAsync.Result;
            }
            return string.Empty;
        }

        public string GetPageSource()
        {
            var sourceAsync = Browser.GetSourceAsync();
            return sourceAsync.Result;
        }


        private string GetNetworksHomeUrl()
        {
            return "https://www.linkedin.com/";
        }

        public string TargetUrl { get; set; } = string.Empty;
        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool forceDispose)
        {
            Browser.Dispose();
        }


        private class RequestHandlerCustom : IRequestHandler
        {
            private readonly EmbedBrowser _embedBrowser;

            public RequestHandlerCustom(EmbedBrowser embedBrowser)
            {
                _embedBrowser = embedBrowser;
            }

            public bool CanGetCookies(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
            {
                return true;
            }

            public bool CanSetCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
            {
                return true;
            }

            public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy,
                string host, int port, string realm, string scheme, IAuthCallback callback)
            {
                if (isProxy)
                {
                    callback.Continue(_embedBrowser.AccountModel.ProxyModel.ProxyUsername,
                        _embedBrowser.AccountModel.ProxyModel.ProxyPassword);

                    return true;
                }
                return false;
            }

            public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame,
                IRequest request, IResponse response)
            {
                return null;
            }

            public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
                bool isRedirect)
            {
                return false;
            }

            public bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
            {
                throw new NotImplementedException();
            }

            public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame,
                IRequest request, IRequestCallback callback)
            {
                callback.Dispose();
                return CefReturnValue.Continue;
            }

            public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode,
                string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
            {
                return false;
            }

            public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
                WindowOpenDisposition targetDisposition, bool userGesture)
            {
                return false;
            }

            public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
            {
            }

            public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
            {
                return url.StartsWith("https://www.linkedin.com/");
            }

            public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize,
                IRequestCallback callback)
            {
                return false;
            }

            public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser,
                CefTerminationStatus status)
            {
            }

            public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
            {
            }


            public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame,
                IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
            {
                if (!_embedBrowser.Dispatcher.CheckAccess())
                    _embedBrowser.Dispatcher.BeginInvoke(new Action(delegate
                    {
                        _embedBrowser.UrlBar.Text = _embedBrowser.Browser.Address;
                    }));
                else
                    _embedBrowser.UrlBar.Text = _embedBrowser.Browser.Address;
            }

            public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
                IResponse response, ref string newUrl)
            {
            }

            public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
                IResponse response)
            {
                return false;
            }

            public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy,
                string host, int port, X509Certificate2Collection certificates,
                ISelectClientCertificateCallback callback)
            {
                return false;
            }
        }

        public class ProxyRequestHandler : IRequestHandler
        {
            private readonly EmbedBrowser _embedBrowser;

            private readonly string _password;

            private readonly string _userName;


            public ProxyRequestHandler(string userName, string password, EmbedBrowser embedBrowser)
            {
                // get the proxy username
                _userName = userName;

                // get the proxy password
                _password = password;

                _embedBrowser = embedBrowser;
            }



            bool IRequestHandler.OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame,
                string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
            {
                return OnOpenUrlFromTab(browserControl, browser, frame, targetUrl, targetDisposition, userGesture);
            }


            bool IRequestHandler.OnCertificateError(IWebBrowser browserControl, IBrowser browser,
                CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
            {
                return false;
            }

            void IRequestHandler.OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
            {
            }

            CefReturnValue IRequestHandler.OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser,
                IFrame frame, IRequest request, IRequestCallback callback)
            {
                return CefReturnValue.Continue;
            }

            bool IRequestHandler.GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame,
                bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
            {
                if (isProxy)
                {
                    callback.Continue(_userName, _password);

                    return true;
                }

                return false;
            }

            void IRequestHandler.OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser,
                CefTerminationStatus status)
            {
            }

            bool IRequestHandler.OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl,
                long newSize, IRequestCallback callback)
            {
                return false;
            }


            bool IRequestHandler.OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
            {
                return url.StartsWith("mailto");
            }

            void IRequestHandler.OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
            {
            }

            bool IRequestHandler.OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame,
                IRequest request, IResponse response)
            {
                return false;
            }

            IResponseFilter IRequestHandler.GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser,
                IFrame frame, IRequest request, IResponse response)
            {
                return null;
            }

            void IRequestHandler.OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame,
                IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
            {
                if (!_embedBrowser.Dispatcher.CheckAccess())
                    _embedBrowser.Dispatcher.BeginInvoke(new Action(delegate
                    {
                        _embedBrowser.UrlBar.Text = _embedBrowser.Browser.Address;
                    }));
                else
                    _embedBrowser.UrlBar.Text = _embedBrowser.Browser.Address;
            }

            public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy,
                string host, int port, X509Certificate2Collection certificates,
                ISelectClientCertificateCallback callback)
            {
                return false;
            }

            public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
                IResponse response, ref string newUrl)
            {
            }


            protected virtual bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame,
                string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
            {
                return false;
            }

            public bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
            {
                return true;
            }

            public bool CanGetCookies(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
            {
                return true;
            }

            public bool CanSetCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
            {
                return true;
            }

            public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
            {
                return true;
            }
        }
        internal class MenuHandler : IContextMenuHandler
        {
            private const int Refresh = 1;
            private const int Back = 2;
            private const int Forward = 3;
            void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
            {
                //To disable the menu then call clear
                model.Clear();
                //Add new custom menu items
                //model.AddItem((CefMenuCommand)Refresh, "Refresh");
                //model.AddItem((CefMenuCommand)Back, "Back");
                //model.AddItem((CefMenuCommand)Forward, "Forward");

            }
            bool IContextMenuHandler.OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
            {
                if ((int)commandId == Refresh)
                {
                    browser.Reload();
                }
                if ((int)commandId == Back)
                {
                    browser.GoBack();
                }
                if ((int)commandId == Forward)
                {
                    browser.GoForward();
                }

                return false;
            }

            void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
            {

            }

            bool IContextMenuHandler.RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
            {
                return false;
            }
        }



    }

    public class CookieObject
    {
        public string Comment { get; set; }
        public object CommentUri { get; set; }
        public bool HttpOnly { get; set; }
        public bool Discard { get; set; }
        public string Domain { get; set; }
        public bool Expired { get; set; }
        public DateTime Expires { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Port { get; set; }
        public bool Secure { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Value { get; set; }
        public int Version { get; set; }
    }
    internal class CookieDetails
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Domain { get; set; }
    }
}
