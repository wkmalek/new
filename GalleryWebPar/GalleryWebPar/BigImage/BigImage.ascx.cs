using System;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GalleryWebPar.VisualWebPart1;
using Microsoft.SharePoint;

namespace GalleryWebPar.BigImage
{
    [ToolboxItemAttribute(false)]
    public partial class BigImage : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public BigImage()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var PostID = UrlHelper.GetQueryString("ID");
            string query = "<Where><And><Eq><FieldRef Name=\'NewsID\' /><Value Type=\'Text\'>"+PostID+"</Value></Eq><Eq><FieldRef Name=\'IsThumbnail\' /><Value Type=\'Boolean\'>1</Value></Eq></And></Where>"
                ;
            var list = QueryHelper.GetListItem(HttpContext.Current.Request.Url, "NewsImages", query, 6);
            if (list.Count == 1)
            {
                var item = list.Cast<SPListItem>().SingleOrDefault();
                BigImg.ImageUrl = "http://newpressweb:40375/"+item.Url;
            }
        }
    }
}
