using BlogSystem.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data.Models
{
    public class BlogPost : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }


    }
}
