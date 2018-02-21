using System;
using Microsoft.SharePoint;

namespace Helper
{
    public static class QueryHelper
    {
        public static SPListItemCollection GetListItem(Uri siteUri, string listPath, string queryXml, uint rowCount,
            string folderName)
        {
            SPList list;
            using (SPSite site = new SPSite(siteUri.ToString().TrimEnd('/')))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    list = web.GetList(listPath);
                }
            }

            SPQuery query = new SPQuery();
            query.Query = queryXml;
            query.RowLimit = rowCount;
            query.ViewFields = string.Concat(
                "<FieldRef Name='Title'/>"
            );

            if (!String.IsNullOrEmpty(folderName))
            {
                SPFolder searchFolder = list.RootFolder.SubFolders[folderName];
                query.Folder = searchFolder;
                query.ViewAttributes = "Scope=\"Recursive\"";
            }

            SPListItemCollection itemColl = list.GetItems(query);
            return itemColl;
        }

    }
}