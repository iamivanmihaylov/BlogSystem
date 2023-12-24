using BlogSystem.Data.Common.Models;

namespace BlogSystem.Data.Models
{
    public class BlogPostTag : BaseDeletableModel<int>
    {
        public BlogPost BlogPost { get; set; }

        public int BlogPostId { get; set; }

        public string Text { get; set; }
    }
}