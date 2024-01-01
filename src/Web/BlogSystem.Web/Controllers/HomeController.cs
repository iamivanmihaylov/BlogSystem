namespace BlogSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using BlogSystem.Data.Models;
    using BlogSystem.Services.Data.Contracts;
    using BlogSystem.Web.ViewModels;
    using BlogSystem.Web.ViewModels.ViewModels.BlogPostVMs;
    using BlogSystem.Web.ViewModels.ViewModels.Home;
    using BlogSystem.Web.ViewModels.ViewModels.HomeVMs;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IBlogPostService blogPostService;
        private readonly IProjectService projectService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IBlogPostService blogPostService, IProjectService projectService, UserManager<ApplicationUser> userManager)
        {
            this.blogPostService = blogPostService;
            this.projectService = projectService;
            this.userManager = userManager;
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

        public async Task<IActionResult> About()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = new AboutViewModel
            {
                Categories = this.projectService.GetAllProjectCategories<CategoryViewModel>(user.Id),
            };

            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
