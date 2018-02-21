using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint.WebControls;

namespace NewsFeedWP.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VisualWebPart1()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        

        protected void Page_Load(object sender, EventArgs e)
        {
            PostOnListViewModel post = new PostOnListViewModel()
            {
                PostCategory = "Category",
                ImageLink = "images/_thumb1.jpg",
                ArticleTitle = "Lorem Ipsum Dolor Sit Amet Libera Sequitor",
                ShortDescription = "Sed auctor, purus et elementum gravida, felis augue faucibus velit, nec aliquet leo tellus eget purus. Sed est metus, placerat at, commodo ut, ultrices cursus, mauris. Cum sociis natoque penatibus",
                
            };
            PostOnListViewModel post2 = new PostOnListViewModel()
            {
                ArticleTitle = "Lorem Ipsum Dolor Sit Amet Libera Sequitor",
                PostCategory = "Category2",
                ImageLink = "images/_thumb1.jpg",
                ShortDescription = "Sed auctor, purus et elementum gravida, felis augue faucibus velit, nec aliquet leo tellus eget purus. Sed est metus, placerat at, commodo ut, ultrices cursus, mauris. Cum sociis natoque penatibus",

            };

            List<PostOnListViewModel> list = new List<PostOnListViewModel>();
            list.Add(post);
            list.Add(post2);

            Posts.DataSource = list;
            Posts.DataBind();

        }

        
    }
}
