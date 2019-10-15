using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace BaseLib.Handlers.WebHandlers
{
    public class HttpHelper
    {

        private RequestParameters requestParameters = new RequestParameters();
        HttpWebRequest gRequest;
        private Proxy proxy;
        CookieCollection gCookies;
        HttpWebResponse gResponse;
        public void SetRequestParameters(RequestParameters requestParameters)
        {
            this.requestParameters = requestParameters;
        }
        public string getRequest(string url)
        {
            string getHTML = "";
            string responseURI = "";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                setValues(ref request);
                var response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                    responseURI = response.ResponseUri.AbsoluteUri;
                    ReadCookies(response.Cookies);
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    getHTML = reader.ReadToEnd();
                    reader.Close();
                }
                else { return "Error"; }

            }
            catch (Exception ex) { }

            return getHTML;
        }
        public string postRequest(string url, string postData)
        {
            string getHTML = "";
            string responseURI = "";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                setValues(ref request);

                try
                {
                    postData = string.Format(postData);
                    byte[] postBuffer = Encoding.GetEncoding(1252).GetBytes(postData);
                    request.ContentLength = postBuffer.Length;
                    request.Method = "POST";
                    Stream postStreamData = request.GetRequestStream();
                    postStreamData.Write(postBuffer, 0, postBuffer.Length);
                    postStreamData.Close();
                }
                catch { }


                var response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                    responseURI = response.ResponseUri.AbsoluteUri;
                    ReadCookies(response.Cookies);
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    getHTML = reader.ReadToEnd();
                    reader.Close();
                }
                else { return "Error"; }

            }
            catch (Exception ex)
            {
                WebException webEx = (WebException)ex;
                string str = (new StreamReader(webEx.Response.GetResponseStream()).ReadToEnd());
            }

            return getHTML;
        }
        private void ReadCookies(CookieCollection cookies)
        {
            foreach (Cookie cookie in cookies)
            {
                bool flag = true;
                foreach (Cookie cookie2 in requestParameters.cookies)
                    if (cookie.Name.Equals(cookie2.Name) && cookie.Value.Equals(cookie2.Value))
                        flag = false;
                if (flag)
                    requestParameters.cookies.Add(cookie);
            }
        }

        public void setValues(ref HttpWebRequest request)
        {
            try
            {
                request.KeepAlive = requestParameters.KeepAlive;
                //request.Headers = requestParameters.Headers;
                if (!string.IsNullOrEmpty(requestParameters.ContentType)) request.ContentType = requestParameters.ContentType;
                if (!string.IsNullOrEmpty(requestParameters.UserAgent)) request.UserAgent = requestParameters.UserAgent;
                if (!string.IsNullOrEmpty(requestParameters.Host)) request.Host = requestParameters.Host;
                //if (!string.IsNullOrEmpty(requestParameters.Origin)) request.Host = requestParameters.Origin;
                if (!string.IsNullOrEmpty(requestParameters.Referer)) request.Referer = requestParameters.Referer;
                if (!string.IsNullOrEmpty(requestParameters.Accept)) request.ContentType = requestParameters.ContentType;
                if (!string.IsNullOrEmpty(requestParameters.ContentType)) request.ContentType = requestParameters.ContentType;

                request.CookieContainer = new CookieContainer();
                if (requestParameters.cookies != null && requestParameters.cookies.Count > 0)
                    request.CookieContainer.Add(requestParameters.cookies);
                if (requestParameters.cookies == null)
                    requestParameters.cookies = new CookieCollection();

                //if (!string.IsNullOrEmpty(requestParameters.proxy.ProxyAddress) && requestParameters.proxy.ProxyPort != 0)
                //{
                //   // WebProxy webProxy = new WebProxy(requestParameters.proxy.ProxyAddress+":"+requestParameters.proxy.ProxyPort ,false);
                //}

            }
            catch (Exception ex)
            {
            }

        }

        public string postFormDataProxy(Uri formActionUrl, string postData, string Referes)
        {

            gRequest = (HttpWebRequest)WebRequest.Create(formActionUrl);

            //gRequest.ServicePoint.Expect100Continue = false;
            gRequest.Method = "POST";
            gRequest.Host = "www.instagram.com";
            gRequest.KeepAlive = true;
            // gRequest.ContentLength = 41
            gRequest.Headers.Add("Origin", "https://www.instagram.com");
            gRequest.Headers.Add("X-Instagram-AJAX", "1");
            gRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            gRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            gRequest.Accept = "*/*";
            gRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
            string ssrftoken = "";
            if (requestParameters.cookies.Count > 0)
            {
                foreach (Cookie ck in requestParameters.cookies)
                {
                    if (ck.Name == "csrftoken")
                    {
                        ssrftoken = ck.Value;
                        break;
                    }

                }
            }

            gRequest.Headers.Add("X-CSRFToken", ssrftoken);
            gRequest.Headers.Add("DNT", "1");
            gRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            gRequest.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            gRequest.Referer = "https://www.instagram.com/";

            gRequest.CookieContainer = new CookieContainer();
            #region CookieManagement


            //logic to postdata to the form
            try
            {
                string postdata = string.Format(postData);
                byte[] postBuffer = System.Text.Encoding.UTF8.GetBytes(postData);
                gRequest.ContentLength = postBuffer.Length;
                Stream postDataStream = gRequest.GetRequestStream();
                postDataStream.Write(postBuffer, 0, postBuffer.Length);
                postDataStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Logger.LogText("Internet Connectivity Exception : "+ ex.Message,null);
            }
            //post data logic ends

            //Get Response for this request url
            string html;
            try
            {
                gResponse = (HttpWebResponse)gRequest.GetResponse();
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                string str = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                //Logger.LogText("Response from " + url + ":" + ex.Message, null);
            }



            //check if the status code is http 200 or http ok

            if (gResponse.StatusCode == HttpStatusCode.OK)
            {
                //get all the cookies from the current request and add them to the response object cookies
                gResponse.Cookies = gRequest.CookieContainer.GetCookies(gRequest.RequestUri);
                //check if response object has any cookies or not
                //Added by sandeep pathak
                //gCookiesContainer = gRequest.CookieContainer;  

                if (gResponse.Cookies.Count > 0)
                {
                    //check if this is the first request/response, if this is the response of first request gCookies
                    //will be null
                    if (this.gCookies == null)
                    {
                        gCookies = gResponse.Cookies;
                    }
                    else
                    {
                        foreach (Cookie oRespCookie in gResponse.Cookies)
                        {
                            bool bMatch = false;
                            foreach (Cookie oReqCookie in this.gCookies)
                            {
                                if (oReqCookie.Name == oRespCookie.Name)
                                {
                                    oReqCookie.Value = oRespCookie.Value;
                                    bMatch = true;
                                    break; // 
                                }
                            }
                            if (!bMatch)
                                this.gCookies.Add(oRespCookie);
                        }
                    }
                }
                #endregion


                try
                {
                    StreamReader reader = new StreamReader(gResponse.GetResponseStream());
                    string responseString = reader.ReadToEnd();
                    reader.Close();
                    //Console.Write("Response String:" + responseString);
                    return responseString;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
            else
            {
                return "Error in posting data";
            }

        }
    }

   
    public class RequestParameters
    {
        RequestParameters requestParameters;
        public bool KeepAlive { get; set; }
        public string ContentType { get; set; }
        public string Accept { get; set; }
        public string Host { get; set; }
        public string Origin { get; set; }

        public string Referer { get; set; }
        public string UserAgent { get; set; }
        private CookieCollection _cookies = new CookieCollection();
        public CookieCollection cookies
        {
            get { return _cookies; }
            set { _cookies = value; }
        }

        public Proxy proxy { get; set; }
        private WebHeaderCollection _Headers = new WebHeaderCollection();
        public WebHeaderCollection Headers
        {
            get
            {
                return _Headers;
            }
            set
            {
                _Headers = value;
            }
        }


        public RequestParameters GetRequestParameters()
        {
            return this.requestParameters;
        }

        public void SetRequestParameters(RequestParameters requestParameters)
        {
            this.requestParameters = requestParameters;
        }
    }

    interface IProxy
    {
        IProxy Proxy();
        string ProxyAddress();
        int ProxyPort();
        string ProxyUserName();
        string ProxyPassword();
        IProxy GetProxy();
        void SetProxy(Proxy proxy);

    }
    public class Proxy
    {
        public Proxy proxy;
        public string ProxyAddress { get; set; }
        public int ProxyPort { get; set; }
        public string ProxyUserName { get; set; }
        public string ProxyPassword { get; set; }


    }
}
