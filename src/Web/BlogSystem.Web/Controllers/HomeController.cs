namespace BlogSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using BlogSystem.Services.Data.Contracts;
    using BlogSystem.Web.ViewModels;
    using BlogSystem.Web.ViewModels.ViewModels.BlogPostVMs;
    using BlogSystem.Web.ViewModels.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IBlogPostService blogPostService;

        public HomeController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                BlogPosts = await this.blogPostService.GetAllBlogPostsAsync<BlogPostHomeViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
