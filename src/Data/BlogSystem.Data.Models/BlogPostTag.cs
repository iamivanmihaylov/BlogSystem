using BlogSystem.Data.Common.Models;
using System.Collections;
using System.Collections.Generic;

namespace BlogSystem.Data.Models
{
    public class BlogPostTag : BaseDeletableModel<int>
    {
        public string Text { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}