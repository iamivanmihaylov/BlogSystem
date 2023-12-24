// ReSharper disable VirtualMemberCallInConstructor
using BlogSystem.Data.Common.Models;

namespace BlogSystem.Data.Models
{
    public class Project : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ProjectCategory Category { get; set; }

        public string Content { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}