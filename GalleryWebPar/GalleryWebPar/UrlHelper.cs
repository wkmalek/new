using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GalleryWebPar.VisualWebPart1
{
    public static class UrlHelper
    {
        public static string GetQueryString(string key)
        {
            return HttpContext.Current.Request.QueryString[key];
        }
    }
}
