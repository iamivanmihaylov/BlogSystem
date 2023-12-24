namespace BlogSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BlogSystem.Data.Common.Models;

    public class BlogPostImage : BaseDeletableModel<int>
    {
        public BlogPost BlogPost { get; set; }

        public int BlogPostId { get; set; }

        public string ImageUrl { get; set; }
    }
}
