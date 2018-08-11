using BaseLib.Handlers.WebHandlers;
using BaseUI.FBViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseUI.BasicFunctionality.FBFunctionality
{
    public class FbAccountActions
    {
        HttpHelper objHttpHelper = new HttpHelper();
        FbUrlDataBind FbUrl = new FbUrlDataBind();
        FBUsersDetails fbUserDetails = new FBUsersDetails();
        public void LoginStart(ref FBMainPageViewModel fbMainView, RequestParameters reqParams, ref FBUsersDetails fbUserDetails)
        {
            try
            {
                objHttpHelper.SetRequestParameters(reqParams);
                FbUrl.FbLoginPageGetHtml = objHttpHelper.getRequest("https://www.facebook.com/");
                FbUrl.FbLoginPageGetUrl = "https://en-gb.facebook.com/login";
                objHttpHelper.SetRequestParameters(reqParams);
                FbUrl.FbLoginPageGetHtml = objHttpHelper.getRequest(FbUrl.FbLoginPageGetUrl);
                reqParams.Referer = "https://www.facebook.com/";
                objHttpHelper.SetRequestParameters(reqParams);
                string lsd = Utils.getBetween(FbUrl.FbLoginPageGetHtml, "name=\"lsd\" value=\"", "\"");
                string str = WebUtility.UrlEncode(fbMainView.UserName);

                FbUrl.FbLoginPostData = "lsd=" + lsd + "&display=&enable_profile_selector=&isprivate=&legacy_return=0&profile_selector_ids=&return_session=&skip_api_login=&signed_next=&trynum=1&timezone=-330&lgndim=eyJ3IjoxMzYwLCJoIjo3NjgsImF3IjoxMzYwLCJhaCI6NzI4LCJjIjoyNH0%3D&lgnrnd=214256_XDPn&lgnjs=1506509243&email=" + WebUtility.UrlEncode(fbMainView.UserName) + "&pass=" + WebUtility.UrlEncode(fbMainView.UserPassword) + "&prefill_contact_point=" + WebUtility.UrlEncode(fbMainView.UserName) + "&prefill_source=browser_dropdown&prefill_type=contact_point";
                FbUrl.FbLoginPostUrl = "https://www.facebook.com/login.php?login_attempt=1&lwv=111";

                reqParams.ContentType = @"application/x-www-form-urlencoded";
                reqParams.Referer = "https://www.facebook.com/";

                FbUrl.FbLoginPostHtml = objHttpHelper.postRequest(FbUrl.FbLoginPostUrl, FbUrl.FbLoginPostData);
                string reqinfo = Utils.getBetween(FbUrl.FbLoginPostHtml, "menu&quot;,&quot;", "_menu_click&quot;");
                fbUserDetails.FBUserFullName = Utils.getBetween(FbUrl.FbLoginPostHtml, "class=\"linkWrap noCount\">", "</div>");

                if (reqinfo.Contains("logout"))
                {
                    StreamWriter sw = new StreamWriter("D:\\TempCookie1.txt");
                    string tempCookie = "";

                    fbMainView.LoginStatus = true;
                    fbUserDetails.FBUserPassword = fbMainView.UserPassword;
                    GetWelcomePageValues(ref fbUserDetails);

                    foreach (Cookie cookie in reqParams.cookies)
                    {
                        tempCookie = tempCookie + JsonConvert.SerializeObject(cookie) + "\n";
                    }
                    try
                    {
                        sw.Write(tempCookie);
                        sw.Close();
                    }
                    catch (Exception ex) { }
                }

            }
            catch (Exception ex)
            { //MessageBox.Show(ex.ToString()); 
            }
        }


        private void GetWelcomePageValues(ref FBUsersDetails fbUserDetails)
        {
            try
            {
                fbUserDetails.FBAccountId = Utils.getBetween(FbUrl.FbLoginPostHtml, "\"ACCOUNT_ID\":\"", "\"");
                FbUrl.fb_dtsg = Utils.getBetween(FbUrl.FbLoginPostHtml, "{\"token\":\"", "\"");
                FbUrl.fb_dtsg = Uri.EscapeDataString(FbUrl.fb_dtsg);
                FbUrl._spin_r = Utils.getBetween(FbUrl.FbLoginPostHtml, "spin_r\":", ",");
                FbUrl._spin_t = Utils.getBetween(FbUrl.FbLoginPostHtml, "_spin_t\":", ",");
                FbUrl.ClientRevision = Utils.getBetween(FbUrl.FbLoginPostHtml, "server_revision\":", ",");
                fbUserDetails.FBUserName = Utils.getBetween(FbUrl.FbLoginPostHtml, "title=\"" + fbUserDetails.FBUserFullName + "\" href=\"", "?");
                fbUserDetails.FBUserName = fbUserDetails.FBUserName.Replace("https://www.facebook.com/", "");
                FbUrl.FbProfileUrl = "https://www.facebook.com/" + fbUserDetails.FBUserName;
                FbUrl.FbProfileHtml = objHttpHelper.getRequest(FbUrl.FbProfileUrl);
                if (FbUrl.FbProfileHtml.Contains("No automatic alt text available.\" src=\""))
                    fbUserDetails.FBUserPhotoUrl = Utils.getBetween(FbUrl.FbProfileHtml, "No automatic alt text available.\" src=\"", "\"");
                else if (FbUrl.FbProfileHtml.Contains("img\" alt=\"your profile photo\" src=\""))
                    fbUserDetails.FBUserPhotoUrl = Utils.getBetween(FbUrl.FbProfileHtml, "img\" alt=\"your profile photo\" src=\"", "\"");
                else if (FbUrl.FbProfileHtml.Contains("<img class=\"profilePic"))
                {
                    string temp = Utils.getBetween(FbUrl.FbProfileHtml, "<img class=\"profilePic", "https");
                    fbUserDetails.FBUserPhotoUrl = Utils.getBetween(FbUrl.FbProfileHtml, temp, "\"");
                }
                fbUserDetails.FBUserPhotoUrl = WebUtility.HtmlDecode(fbUserDetails.FBUserPhotoUrl);
                FbUrl.jazoest = "265817084536781103101118551065865817251684511688781178355";
            }
            catch (Exception ex)
            {
            }
        }

        public List<string> SearchSuggestion(FBMainPageViewModel fbMainView, FBUsersDetails fbUserDetails)
        {
            List<string> suggestions = new List<string>();
            FbUrl.FbSuggestKeyword = fbMainView.SearchFriend;
            FbUrl.FbSuggestKeyword = Uri.EscapeDataString(FbUrl.FbSuggestKeyword);

            try
            {
                try
                {
                    fbMainView.SuggestionList.Clear();
                }
                catch { }

                if (fbMainView.LoginStatus)
                {
                    FbUrl.FbSuggestUrl = "https://www.facebook.com/typeahead/search/facebar/query/?dpr=1&value=[%22" + FbUrl.FbSuggestKeyword + "%22]&context=facebar&grammar_version=bee09f93fa732cfa59a1cb6d9f450d3892424e49&content_search_mode&viewer=" + fbUserDetails.FBAccountId + "&rsp=search&qid=10&max_results=10&sid=0.9577593327652711&__user=" + fbUserDetails.FBAccountId + "&__a=1&__dyn=5V4cjEzUGByK5A9UoHaEWC5ER6yUmyVbGAEG8zCC_8267UDAyoS2N6wAxubwTwFGEa8Z1ebkwy6UnGii9KcVrDG4Xze2ei4GVk3uaVVojxCVFEKjGqu58nUOaAz8lUlwkEG9J3o9ohxGbwBxrxqrXG48B1G7U84i9CUKazpK5EG2eVQm5EgwECwTAyrK4rGUohESfyaBy9FoO784afxK9yUvybx7yEGLAG2C6riy6bybU_Z128hohxOUK5E-bQ6e4oC&__af=h0&__req=f&__be=0&__pc=PHASED%3ADEFAULT&__rev=3372347&__spin_r=" + FbUrl._spin_r + "&__spin_b=trunk&__spin_t=" + FbUrl._spin_t;
                    FbUrl.FbSuggestGetHtml = objHttpHelper.getRequest(FbUrl.FbSuggestUrl);

                    string str = "";
                    var userNames = Regex.Split(FbUrl.FbSuggestGetHtml, "\"name\":\"").ToList();
                    userNames.ForEach(strs =>
                    {
                        if (strs.Contains("\"display\":[\"") && !strs.Contains("\n"))
                            suggestions.Add(Utils.getBetween(strs, "\"display\":[\"", "\""));
                    });
                }

            }
            catch { }
            return suggestions;
        }
    }
}

