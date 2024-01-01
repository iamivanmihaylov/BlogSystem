// ReSharper disable VirtualMemberCallInConstructor
using BlogSystem.Data.Common.Models;

namespace BlogSystem.Data.Models
{
    public class Project : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ProjectCategory ProjectCategory { get; set; }

        public int ProjectCategoryId { get; set; }

        public string Content { get; set; }
    }
}