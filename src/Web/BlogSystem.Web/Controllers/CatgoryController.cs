using BlogSystem.Web.ViewModels.InputModels.ProjectCategoryIMs;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class CatgoryController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ProjectCategoryInputModel inputModel)
        {
            return this.Json(inputModel);
        }
    }
}
