using BlogSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Web.ViewModels.DTOs.ReactionDTOs
{
    public class ReactionInputDTO
    {
        public int BlogPostId { get; set; }

        public ReactionType ReactionType { get; set; }
    }

}
