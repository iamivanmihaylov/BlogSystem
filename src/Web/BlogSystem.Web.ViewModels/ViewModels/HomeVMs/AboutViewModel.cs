using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Web.ViewModels.ViewModels.HomeVMs
{
    public class AboutViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
