namespace BlogSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BlogSystem.Data.Common.Models;

    public class BlogPost : BaseDeletableModel<int>
    {
        public BlogPost()
        {
            this.BlogPostReactions = new HashSet<BlogPostReaction>();
            this.BlogPostTags = new HashSet<BlogPostTag>();
        }

        public string Title { get; set; }

        public string HeadingImageUrl { get; set; }

        public string Content { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<BlogPostReaction> BlogPostReactions { get; set; }

        public virtual ICollection<BlogPostTag> BlogPostTags { get; set; }

    }
}
