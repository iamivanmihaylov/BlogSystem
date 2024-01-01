using BlogSystem.Data.Models;
using BlogSystem.Services.Mapping;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Web.ViewModels.InputModels.ProjectIMs
{
    public class CreateProjectInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }
    }
}
