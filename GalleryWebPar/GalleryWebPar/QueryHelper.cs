using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace GalleryWebPar.VisualWebPart1
{
    public static class QueryHelper
    {
        public static SPListItemCollection GetListItem(Uri siteUri, string listPath, string queryXml, uint rowCount)
        {
            SPList list;
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    list = web.GetList(listPath);
                }
            }

            SPQuery query = new SPQuery();
            query.Query = queryXml;
            query.RowLimit = rowCount;
            query.ViewFields = string.Concat
            (
                "<FieldRef Name='Title'/>",
                "<FieldRef Name='Name'/>",
                "<FieldRef Name='File Type'/>",
                "<FieldRef Name='Preview'/>"
            );

            SPListItemCollection itemColl = list.GetItems(query);
            return itemColl;
        }
    }
}
