using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Services.Data.Contracts
{
    public interface IProjectService
    {
        Task CreatProjectCategoryAsync(string userId, string name, bool isGithubIntegrated);

        IEnumerable<T> GetAllProjectCategories<T>(string userId);

        IEnumerable<T> GetProjectsByCategoryId<T>(int categoryId);

        Task CreateProjectAsync(int categoryId, string title, string description, string content);
    }
}
