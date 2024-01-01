using BlogSystem.Data.Models;
using BlogSystem.Services.Data.Contracts;
using BlogSystem.Web.ViewModels.InputModels.ProjectCategoryIMs;
using BlogSystem.Web.ViewModels.ViewModels.ProjectVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;

namespace BlogSystem.Web.Controllers
{
    public class CatgoryController : Controller
    {
        private readonly IProjectService projectService;
        private readonly UserManager<ApplicationUser> userManager;

        public CatgoryController(IProjectService projectService,
            UserManager<ApplicationUser> userManager)
        {
            this.projectService = projectService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult ById(int id)
        {
            var viewModel = new AllProjectsInCategoryViewModel
            {
                Id = id,
                Porjects = this.projectService.GetProjectsByCategoryId<SmallCardProjectViewModel>(id),
            };

            return this.View(viewModel);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ProjectCategoryInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.projectService.CreatProjectCategoryAsync(user.Id, inputModel.Name, inputModel.IsGithubIntegrated);

            return this.RedirectToAction("About", "Home");
        }
    }
}
