using BlogSystem.Web.ViewModels.InputModels.ProjectCategoryIMs;
using BlogSystem.Web.ViewModels.InputModels.ProjectIMs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogSystem.Web.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Create(int id)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, CreateProjectInputModel createProjectInputModel)
        {
            var json = new
            {
                id,
                createProjectInputModel,
            };

            return this.Json(json);
        }
    }
}
