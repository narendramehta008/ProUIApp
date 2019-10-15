using BaseLibs.Handlers.DataHandlers;
using CefSharp;
using HtmlAgilityPack;
using ProUIApp.View.AccountView;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProUIApp.Functions
{

    public class Automation
    {
        private EmbedBrowser _embedBrowser;

        public Automation(EmbedBrowser browserWindow)
        {
            _embedBrowser = browserWindow;
        }

        public string GetPath(string pageSource, string attributeType, AttributeIdentifierType attributeIdentifierType, params string[] containsList)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(pageSource);
            var nodeCollection = htmlDoc.DocumentNode.SelectNodes($"//{attributeType}");
            string idOrClassName = "";
            try
            {
                foreach (var node in nodeCollection)
                {
                    var outerHtml = node.OuterHtml;

                    if (!Utils.IsStringContainsItemFromList(outerHtml, containsList)
                        || (attributeIdentifierType.Equals(AttributeIdentifierType.Id) && string.IsNullOrEmpty(node?.Id)))
                        continue;

                    if (attributeIdentifierType.Equals(AttributeIdentifierType.Id))
                        idOrClassName = node.Id;
                    else if (attributeIdentifierType.Equals(AttributeIdentifierType.ClassName))
                        idOrClassName = Utils.GetBetween(outerHtml, "class=\"", "\"");
                    else if (attributeIdentifierType.Equals(AttributeIdentifierType.Xpath))
                        idOrClassName = node.XPath;
                    if (!string.IsNullOrEmpty(idOrClassName))
                        break;
                }
            }
            catch (Exception exception)
            {
                // exception.DebugLog();
            }

            return idOrClassName;
        }
        public bool LoadAndClick(string attributeType, AttributeIdentifierType attributeIdentifierType, params string[] containsList)
        {
            string script = "";
            try
            {
                var idOrClass = GetPath(_embedBrowser.GetPageSource(), attributeType, attributeIdentifierType, containsList);
                if (string.IsNullOrEmpty(idOrClass))
                    return false;

                if (attributeIdentifierType.Equals(AttributeIdentifierType.Id))
                    script = $"document.getElementById('{idOrClass}').click();";
                else if (attributeIdentifierType.Equals(AttributeIdentifierType.ClassName))
                    script = $"document.getElementsByClassName('{idOrClass}')[0].click();";
                else if (attributeIdentifierType.Equals(AttributeIdentifierType.Xpath))
                    script =
                        $"document.evaluate('{idOrClass.Replace("\'", @"\\'")}', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click();";


                if (ExecuteScript(script).Success)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    return true;
                }

            }
            catch (Exception exception)
            {
                // exception.DebugLog();
            }

            return false;
        }

        public bool LoadAndMouseClick(string attributeType, AttributeIdentifierType attributeIdentifierType, params string[] containsList)
        {

            try
            {
                var idOrClass = GetPath(_embedBrowser.GetPageSource(), attributeType, attributeIdentifierType, containsList);
                if (string.IsNullOrEmpty(idOrClass))
                    return false;
                return ExecuteXAndYClick(idOrClass, attributeIdentifierType);
            }
            catch (Exception exception)
            {
                // exception.DebugLog();
            }
            finally
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            return false;
        }

        public bool ExecuteXAndYClick(string elementName, AttributeIdentifierType attributeIdentifierType)
        {
            var script = attributeIdentifierType == AttributeIdentifierType.Id
                ? $"document.getElementById('{elementName}').scrollIntoView()"
                : $"document.getElementsByClassName('{elementName}')[0].scrollIntoView()";

            var demo = ExecuteScript(script);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var axis = GetXAndY(elementName, attributeIdentifierType);
            _embedBrowser.MouseClick(axis.Key, axis.Value, delayAfter: 2);
            return (axis.Key != 0 || axis.Value != 0);
        }

        public KeyValuePair<int, int> GetXAndYPositionByScript(string attributeType, AttributeIdentifierType attributeIdentifierType, params string[] containsList)
        {
            KeyValuePair<int, int> xAndYPosition = new KeyValuePair<int, int>();

            try
            {
                var idOrClass = GetPath(_embedBrowser.GetPageSource(), attributeType, attributeIdentifierType, containsList);
                if (string.IsNullOrEmpty(idOrClass))
                    return xAndYPosition;
                return GetXAndY(idOrClass, AttributeIdentifierType.Id);
            }
            catch (Exception exception)
            {
                //exception.DebugLog();
            }
            return xAndYPosition;
        }




        public KeyValuePair<int, int> GetXAndY(string elementName, AttributeIdentifierType attributeIdentifierType = AttributeIdentifierType.Id)
        {
            KeyValuePair<int, int> xAndY = new KeyValuePair<int, int>();
            var scripty = attributeIdentifierType == AttributeIdentifierType.Id ? $"$('#{elementName}').offset().top" : $"document.getElementsByClassName('{elementName}')[0].getBoundingClientRect().top";
            var scriptx = attributeIdentifierType == AttributeIdentifierType.Id ? $"$('#{elementName}').offset().left" : $"document.getElementsByClassName('{elementName}')[0].getBoundingClientRect().left";

            if (ExecuteScript(scriptx, 0).Success)
            {
                var scriptResponse = ExecuteScript(scriptx, 0);
                var x = Utils.ConvertDoubleAndInt(scriptResponse.Result.ToString());
                scriptResponse = ExecuteScript(scripty, 0);
                var y = Utils.ConvertDoubleAndInt(scriptResponse.Result.ToString());
                xAndY = new KeyValuePair<int, int>(x, y);
                return xAndY;
            }
            return xAndY;
        }


        public JavascriptResponse ExecuteScript(string script, int delayInSec = 2)
        {
            var resp = _embedBrowser.Browser.EvaluateScriptAsync(script).Result;
            Thread.Sleep(TimeSpan.FromSeconds(delayInSec));
            return resp;
        }

        public string GetCurrentAddress()
        {
            var address = "";
            try
            {
                System.Windows.Application.Current.Dispatcher.Invoke(
                    () => { address = _embedBrowser.Browser.Address; });
            }
            catch (Exception)
            {
            }
            return address;
        }

        public void ScrollWindow(int scrollDown = 2000, bool isDown = true)
        {
            int down = isDown ? 500 : -500;
            var downTimes = scrollDown / 500;
            for (int i = 1; i < downTimes; i++)
            {
                Thread.Sleep(100);
                ExecuteScript($"window.scrollBy(0, {down})");
            }
        }

        public string ScrollAndSaveCurrentPage()
        {
            // click to go to second page if pageurl not have pageNum
            var pageSource = _embedBrowser.GetPageSource();
            var CurrentPageUrl = GetCurrentAddress();
            var pageNumber = Utils.GetBetween(CurrentPageUrl, "page=", "&");
            if (string.IsNullOrEmpty(pageNumber) && string.IsNullOrEmpty(pageNumber = Utils.GetBetween(CurrentPageUrl + "<>", "page=", "<>")))
                LoadAndClick("button", AttributeIdentifierType.Xpath, "Navigate to page 2");
            else
            {
                int pageNum = 1;
                int.TryParse(pageNumber, out pageNum);
                var nextPage = CurrentPageUrl.Replace($"page={pageNum}", $"page={pageNum + 1}");
                _embedBrowser.Browser.Load(nextPage);
            }
            Thread.Sleep(10000);
            ScrollWindow(4000);
            ExecuteScript($"window.scrollTo(0, 100)");
            return GetCurrentAddress();
        }

        public void LoadPageUrlAndWait(string url, int delayInSec = 10)
        {
            _embedBrowser.Browser.Load(url);
            WhileLoad();
        }
        public void WhileLoad()
        {
            Thread.Sleep(5000);
            var pageResponse = _embedBrowser.GetPageSource();
            while (!pageResponse.Contains("</code>"))
            {
                Thread.Sleep(5000);
                pageResponse = _embedBrowser.GetPageSource();
            }

        }

    }



   
}
