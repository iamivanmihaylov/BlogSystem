// ReSharper disable VirtualMemberCallInConstructor
using BlogSystem.Data.Common.Models;

namespace BlogSystem.Data.Models
{

    public class Subscribtion : BaseDeletableModel<int>
    {
        public string UserEmail { get; set; }
    }
}