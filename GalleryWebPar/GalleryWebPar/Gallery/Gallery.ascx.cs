using System;
using System.ComponentModel;
using System.Runtime.Remoting.Services;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;


namespace GalleryWebPar.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class Gallery : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Gallery()
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
            string query =
                "<Where><Eq><FieldRef Name=\"NewsID\" /><Value Type=\"Text\">"+PostID+"</Value></Eq></Where>";
            var list = QueryHelper.GetListItem(HttpContext.Current.Request.Url, "NewsImages", query, 6);

            Repeater.DataSource = list;
            Repeater.DataBind();
            
        }

        
    }
}
