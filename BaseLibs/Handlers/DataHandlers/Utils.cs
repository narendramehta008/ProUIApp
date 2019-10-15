using System;
using System.Text.RegularExpressions;

namespace BaseLibs.Handlers.DataHandlers
{

    public class Utils
    {
        public static string GetBetween(string source, string startString, string endString)
        {
            string str = "";
            if (source.Contains(startString) && (source.Contains(endString)))
            {
                int start = source.IndexOf(startString) + startString.Length;
                int end = source.IndexOf(endString, start);
                str = source.Substring(start, end - start);
            }
            return str;
        }

        public static string RemoveHtmlTags(string response)
        {
            try
            {
                var resp = Regex.Replace(response, "<.*?>", "")?.Trim();
                return resp;
            }
            catch (Exception ex)
            {
                return response;
            }
        }

        public static int ConvertDoubleAndInt(string v)
        {
            throw new NotImplementedException();
        }

        public static bool IsListContainsString(string element,params string[] containsList)
        {
            var isContains = false;
            foreach (var item in containsList)
                if (isContains = item.Contains(element))
                    break;
            return isContains;
        }
        public static bool IsStringContainsItemFromList(string element, params string[] containsList)
        {
            var isContains = false;
             foreach (var item in containsList)
                if (isContains = element.Contains(item))
                    break;
            return isContains;
        }
    }
}
