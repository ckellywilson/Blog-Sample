using System;
using System.Collections.Generic;

namespace Blog.Domain
{
    /// <summary>
    /// Entry for a blog
    /// </summary>
    public class BlogEntry
    {
        public BlogEntry()
        {
            BlogPosts = new HashSet<BlogPost>();
        }

        /// <summary>
        /// Unique identifier for a <see cref="Blog"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the <see cref="Blog"/>
        /// </summary>
        public string BlogEntryName { get; set; }

        /// <summary>
        /// Date of the <see cref="Blog"/>
        /// </summary>
        public DateTime BlogEntryDate { get; set; }

        /// <summary>
        /// List of <see cref="BlogPost"/>
        /// </summary>
        public HashSet<BlogPost> BlogPosts { get; set; }
    }
}