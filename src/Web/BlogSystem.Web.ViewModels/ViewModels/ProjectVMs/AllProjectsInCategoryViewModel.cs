using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Web.ViewModels.ViewModels.ProjectVMs
{
    public class AllProjectsInCategoryViewModel
    {
        public int Id { get; set; }

        public IEnumerable<SmallCardProjectViewModel> Porjects { get; set; }
    }
}
