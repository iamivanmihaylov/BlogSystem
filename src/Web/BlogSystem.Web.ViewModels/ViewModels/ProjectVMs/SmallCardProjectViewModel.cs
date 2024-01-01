namespace BlogSystem.Web.ViewModels.ViewModels.ProjectVMs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BlogSystem.Data.Models;
    using BlogSystem.Services.Mapping;

    public class SmallCardProjectViewModel : IMapFrom<Project>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
