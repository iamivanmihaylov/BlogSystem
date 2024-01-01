namespace BlogSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BlogSystem.Data.Common.Models;

    public class ProjectCategory : BaseDeletableModel<int>
    {
        public ProjectCategory()
        {
            this.Projects = new HashSet<Project>();
        }

        public string Name { get; set; }

        public bool IsGithubIntegrated { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
