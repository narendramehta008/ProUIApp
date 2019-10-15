using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.Handlers.DataHandlers
{
    public class HtmlAgilityHelper
    {
        public static List<HtmlNode> GetListNodesFromClassName(string pageResponse, string className, HtmlDocument htmlDocument = null)
        {
            var htmlNodes = new List<HtmlNode>();
            try
            {
                if (htmlDocument == null)
                {
                    htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(pageResponse);
                }

                htmlNodes = htmlDocument.DocumentNode.SelectNodes($"//*[contains(@class, '{className}')]").ToList();
            }
            catch (Exception ex)
            {

            }
            return htmlNodes;
        }

        public static List<HtmlNode> GetListNodesFromAttribute(string pageResponse, string attribute, HtmlDocument htmlDocument = null)
        {
            var htmlNodes = new List<HtmlNode>();
            try
            {
                if (htmlDocument == null)
                {
                    htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(pageResponse);
                }

                htmlNodes = htmlDocument.DocumentNode.SelectNodes($"//{attribute}").ToList();
            }
            catch (Exception ex)
            {

            }
            return htmlNodes;
        }

        public static string GetStringTextFromClassName(string pageResponse, string className, HtmlDocument htmlDocument = null)
        {
            return Utils.RemoveHtmlTags(GetListNodesFromClassName(pageResponse, className, htmlDocument)?.FirstOrDefault()?.InnerHtml);
        }
        public static string GetStringFromClassName(string pageResponse, string className, HtmlDocument htmlDocument = null)
        {
            return GetListNodesFromClassName(pageResponse, className, htmlDocument)?.FirstOrDefault()?.OuterHtml;
        }

        public static List<HtmlNode> GetListNodesFromAttribute(string pageResponse, string attribute, AttributeIdentifierType identifierType, HtmlDocument htmlDocument = null, params string[] contains)
        {
            return GetListNodesFromAttribute(pageResponse, attribute, htmlDocument)?.Where(x => Utils.IsStringContainsItemFromList(x.OuterHtml, contains))?.ToList();
        }
        public static List<string> GetListInnerHtmlFromClassName(string pageResponse, string className, HtmlDocument htmlDocument = null)
        {
            return GetListNodesFromClassName(pageResponse, className, htmlDocument).Select(x => Utils.RemoveHtmlTags(x.InnerHtml)).ToList();
        }
    }
    public enum AttributeIdentifierType
    {
        Id,
        ClassName,
        Xpath
    }

}
