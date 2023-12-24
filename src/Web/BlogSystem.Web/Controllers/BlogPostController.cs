using BlogSystem.Data.Models;
using BlogSystem.Services.Data;
using BlogSystem.Services.Data.Contracts;
using BlogSystem.Web.ViewModels.InputModels.BlogPosts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Web.Controllers
{
    [Authorize]
    public class BlogPostController : BaseController
    {
        private readonly IBlogPostService blogPostService;
        private readonly UserManager<ApplicationUser> userManager;

        public BlogPostController(
            IBlogPostService blogPostService,
            UserManager<ApplicationUser> userManager)
        {
            this.blogPostService = blogPostService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var tags = inputModel.Tags
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet() // This is used to remove the duplicate tags if there are any
                .ToList();

            await this.blogPostService.CreateBlogPostAsync(this.userManager.GetUserId(this.User), inputModel.Title, tags, inputModel.Content, inputModel.ImageUrl);

            return this.RedirectToAction(nameof(HomeController.Index), "Home"); // TODO: Make a helper method to remove controller at the end
        }
    }
}
