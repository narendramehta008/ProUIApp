using BaseLib.Handlers.WebHandlers;
using BaseUI.BasicFunctionality.FBFunctionality;
using BaseUI.FBViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
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

namespace ProUIApp.View.FBView
{
    /// <summary>
    /// Interaction logic for FBMainPage.xaml
    /// </summary>
    public partial class FBMainPage : UserControl
    {
        FBMainPageViewModel fbMainViewModel;
        FBUsersDetails FbUser = new FBUsersDetails();
        RequestParameters rp = new RequestParameters();
        RequestParameters reqParams = new RequestParameters();
        HttpHelper objHttpHelper = new HttpHelper();
        List<Thread> listThread = new List<Thread>();
        FbAccountActions objFbAccountAction = new FbAccountActions();
        public FBMainPage()
        {
            InitializeComponent();
            InitializeValues();
        }

        private static FBMainPage obj;

        public static FBMainPage getObj()
        {
            if (obj == null)
                return obj = new FBMainPage();
            return obj;
        }

     
        //  MyHttpHelper freq = new MyHttpHelper();
        bool loginStatus = false;
        string tempCookiePath = "D:\\TempCookie1.txt";
        bool cookieContains = false;
        //UserLogIn_Status.Content = fbUserDetails.FBUserFullName + "  is Logged In";

     
        
        private void InitializeValues()
        {
            try
            {
                fbMainViewModel = new FBMainPageViewModel();
                this.DataContext = fbMainViewModel;

               Thread th =new Thread(() =>
                {
                    try
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                        {
                            fbMainViewModel.LogoSource = "https://image.freepik.com/free-icon/facebook-logo_318-49940.jpg";
                        }
                        ));
                    }
                    catch { }

                });

                th.IsBackground = true;
                th.Start();


                setReqParams("Login");
            }
            catch (Exception ex)
            {
            }
        }



        private void textBox_FriendName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                Thread th = new Thread(() => GetSuggestions());
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
            }

            try
            {
                comboBox_SearchSuggsetion.Dispatcher.Invoke(new Action(delegate
                {
                    comboBox_SearchSuggsetion.IsDropDownOpen = true;
                }));
            }
            catch { }

        }

        private void GetSuggestions()
        {
            try
            {
                comboBox_SearchSuggsetion.Dispatcher.Invoke(new Action(delegate
                {
                    fbMainViewModel.SuggestionList.Clear();
                }));

                List<string> suggestions = objFbAccountAction.SearchSuggestion(fbMainViewModel, FbUser);
                suggestions.ForEach(suggest =>
                {
                    comboBox_SearchSuggsetion.Dispatcher.Invoke(new Action(delegate
                    {
                        fbMainViewModel.SuggestionList.Add(suggest);
                    }));

                });
            }
            catch (Exception ex)
            {
            }
        }
        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (loginStatus)
                {
                    MessageBox.Show("You Are Already Logged In");
                }
                else
                {
                    try
                    {
                        textBox_Password.Dispatcher.Invoke(new Action(delegate
                        {
                            fbMainViewModel.UserPassword = textBox_Password.Password;
                        }
                         ));
                    }
                    catch { }
                    Thread td = new Thread(StartLogin);
                    td.IsBackground = true;
                    td.Start();
                    listThread.Add(td);
                }
            }
            catch { }
        }

        private void StartLogin()
        {
            try
            {
                if (!(string.IsNullOrEmpty(fbMainViewModel.UserName) && string.IsNullOrEmpty(fbMainViewModel.UserPassword)))
                {
                    string query = "SELECT * FROM FBTable WHERE Username='" + fbMainViewModel.UserName + "' ";
                    //DataSet ds = DBHelper.Select(query);
                    if (true)//ds.Tables[0].Rows.Count == 1
                    {

                        //    try
                        //    {
                        //        fbMainViewModel.UserName = ds.Tables[0].Rows[0].Field<string>("Username");
                        //        fbMainViewModel.UserPassword = ds.Tables[0].Rows[0].Field<string>("password");
                        //        fbMainViewModel.LogoSource = ds.Tables[0].Rows[0].Field<string>("ProfilePic");
                        //        string cookies = ds.Tables[0].Rows[0].Field<string>("session");
                        //        List<System.Net.Cookie> cookieJson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Net.Cookie>>(cookies);
                        //        reqParams.cookies = new System.Net.CookieCollection();
                        //        foreach (System.Net.Cookie cookie in cookieJson)
                        //        {
                        //            reqParams.cookies.Add(cookie);
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //    }
                    }

                    else
                    {
                        objFbAccountAction.LoginStart(ref fbMainViewModel, reqParams, ref FbUser);
                        if (fbMainViewModel.LoginStatus == true)
                        {

                            //FacebookImageDownload.getLogin(ref reqParams);
                            //string cookie = Newtonsoft.Json.JsonConvert.SerializeObject(reqParams.cookies);
                            //DBHelper.Insert("INSERT INTO FBTable(Username,Password,Session,ProfilePic) values('" + fbMainViewModel.UserName + "','" + fbMainViewModel.UserPassword + "','" + cookie + "','" + FbUser.FBUserPhotoUrl + "')");
                            //MessageBox.Show(FbUser.FBUserFullName + "  is Logged In Successfully ");
                            //image_UserImage.Dispatcher.Invoke(new Action(delegate
                            //{
                            //    fbMainViewModel.LogoSource = FbUser.FBUserPhotoUrl;
                            //}
                            //));
                        }

                        else
                            MessageBox.Show("Wrong username or password.");
                    }
                }

                else
                    MessageBox.Show("Enter Valid username and password");
            }
            catch
            {
            }
        }

        private void addingCookies(Cookie jsonCookie)
        {
            reqParams.cookies.Add(new System.Net.Cookie("Name", jsonCookie.Name));
        }
        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_searchFriend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_SearchSuggsetion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_UserId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                try
                {
                    textBox_UserId.Dispatcher.Invoke(new Action(delegate
                    {
                        fbMainViewModel.UserName = textBox_UserId.Text;
                    }
                     ));
                }
                catch { }

                if (fbMainViewModel.UserName.Length > 2)
                {
                    //DataSet ds = DBHelper.Select("Select * from FBTable where Username like '" + fbMainViewModel.UserName + "%'");
                    //if (ds.Tables.Count > 0)
                    //{
                    //    fbMainViewModel.UserName = ds.Tables[0].Rows[0].Field<string>("Username");
                    //    fbMainViewModel.UserPassword = ds.Tables[0].Rows[0].Field<string>("password");
                    //    try
                    //    {
                    //        textBox_Password.Dispatcher.Invoke(new Action(delegate
                    //        {
                    //            textBox_Password.Password = fbMainViewModel.UserPassword;
                    //        }
                    //         ));
                    //    }
                    //    catch { }
                    //};
                }

            }
            catch (Exception ex)
            {
            }

        }

        public void setReqParams(string setID)
        {
            switch (setID)
            {
                case "Login":
                    {
                        reqParams.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
                        reqParams.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                        reqParams.Host = "www.facebook.com";
                        reqParams.KeepAlive = true;
                    }
                    break;
            }
            objHttpHelper.SetRequestParameters(reqParams);

        }
    }
}
