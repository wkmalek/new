using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace NewsFeedWebPart.Default
{
    [ToolboxItemAttribute(false)]
    public class Default : WebPart
    {
        protected override void CreateChildControls()
        {
            SPList list = SPContext.Current.Web.Lists["News"];
            SPQuery query = new SPQuery() {Query= "<Query><Where><Eq><FieldRef Name=\"URL\" /><Value Type=\"URL\">cat</Value></Eq></Where><OrderBy><FieldRef Name=\"Created\" Ascending=\"True\" /></OrderBy></Query>" };

            SPView view = list.Views["testView"];  // This view would define Postion > 0
            
            SPListItemCollection items = list.GetItems(query);

        }
    }
}
