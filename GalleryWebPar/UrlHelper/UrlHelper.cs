using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Helper
{
    public static class UrlHelper
    {
        public static string GetQueryString(string key)
        {
            return HttpContext.Current.Request.QueryString[key];
        }

        public static Dictionary<string, string> GetQueryString(params string[] qs)
        {
            return qs.ToDictionary(item => item, item => HttpContext.Current.Request.QueryString[item]);
        }

        public static string MakeQueryString(Dictionary<string, string> qs)
        {
            var sb = new StringBuilder();
            sb.Append("?");
            if (!(qs?.Count > 0)) return "";
            foreach (var item in qs)
            {
                sb.Append(item.Key);
                sb.Append("=");
                sb.Append(item.Value);
                sb.Append("&");
            }

            return sb.ToString();
        }

        public static string GetSpecificQueryFromDict(string key, Dictionary<string, string> dict)
        {
            return dict.FirstOrDefault(x => x.Key == key).Value;
        }
    }
}
