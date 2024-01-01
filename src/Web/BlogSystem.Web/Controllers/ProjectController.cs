using BlogSystem.Services.Data.Contracts;
using BlogSystem.Web.ViewModels.InputModels.ProjectCategoryIMs;
using BlogSystem.Web.ViewModels.InputModels.ProjectIMs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogSystem.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public IActionResult Create(int id)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, CreateProjectInputModel createProjectInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createProjectInputModel);
            }

            await this.projectService.CreateProjectAsync(
                id,
                createProjectInputModel.Title,
                createProjectInputModel.Description,
                createProjectInputModel.Content);

            return this.RedirectToAction("About", "Home", new { id });
        }
    }
}
