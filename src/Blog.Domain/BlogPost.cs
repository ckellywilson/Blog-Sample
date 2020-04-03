using System;

namespace Blog.Domain
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string BlogPostComment { get; set; }
        public DateTime BlogPostDate { get; set; }
        public int BlogEntryId { get; set; }
        public BlogEntry BlogEntry { get; set; }
    }
}