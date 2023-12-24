using BlogSystem.Web.ViewModels.ViewModels.BlogPostVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Web.ViewModels.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<BlogPostHomeViewModel> BlogPosts { get; set; }
    }
}
