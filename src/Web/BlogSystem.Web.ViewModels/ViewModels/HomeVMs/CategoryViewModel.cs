using BlogSystem.Data.Models;
using BlogSystem.Services.Mapping;

namespace BlogSystem.Web.ViewModels.ViewModels.HomeVMs
{
    public class CategoryViewModel : IMapFrom<ProjectCategory>
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}