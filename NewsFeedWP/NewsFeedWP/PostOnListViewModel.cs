using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsFeedWP
{
    public class PostOnListViewModel
    {
        public string ArticleTitle { get; set; }
        public string PostCategory { get; set; }
        public int CommentsCount { get; set; }
        public string ImageLink { get; set; }
        public string ShortDescription { get; set; }
        public string PostAuthor { get; set; }
        public string PostDate { get; set; }

    }
}
