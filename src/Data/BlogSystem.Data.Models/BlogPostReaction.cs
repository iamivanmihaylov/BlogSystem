using BlogSystem.Data.Common.Models;

namespace BlogSystem.Data.Models
{
    public class BlogPostReaction : BaseDeletableModel<int>
    {
        public BlogPost BlogPost { get; set; }

        public int BlogPostId { get; set; }

        public string Session { get; set; }

        public ReactionType ReactionType { get; set; }
    }
}