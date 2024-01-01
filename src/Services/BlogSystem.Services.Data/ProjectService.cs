using BlogSystem.Data.Common.Repositories;
using BlogSystem.Data.Models;
using BlogSystem.Services.Data.Contracts;
using BlogSystem.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Services.Data
{
    public class ProjectService : IProjectService
    {
        private readonly IDeletableEntityRepository<ProjectCategory> projectCategoriesRepository;
        private readonly IDeletableEntityRepository<Project> projectsRepository;

        public ProjectService(
            IDeletableEntityRepository<ProjectCategory> projectCategoryRepository,
            IDeletableEntityRepository<Project> projectRepository)
        {
            this.projectCategoriesRepository = projectCategoryRepository;
            this.projectsRepository = projectRepository;
        }

        public async Task CreateProjectAsync(int categoryId, string title, string description, string content)
        {
            var project = new Project
            {
                Title = title,
                Description = description,
                Content = content,
                ProjectCategoryId = categoryId,
            };

            await this.projectsRepository.AddAsync(project);
            await this.projectsRepository.SaveChangesAsync();
        }

        public async Task CreatProjectCategoryAsync(string userId, string name, bool isGithubIntegrated)
        {
            var projectCategory = new ProjectCategory
            {
                UserId = userId,
                Name = name,
                IsGithubIntegrated = isGithubIntegrated,
            };

            await this.projectCategoriesRepository.AddAsync(projectCategory);
            await this.projectCategoriesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllProjectCategories<T>(string userId)
        {
            var result = this.projectCategoriesRepository
                .All()
                .Where(x => x.UserId == userId)
                .To<T>()
                .ToList();

            return result;
        }

        public IEnumerable<string> GetAllProjectCategoryNames(string userId)
        {
            var result = this.projectCategoriesRepository
                .All()
                .Where(x => x.UserId == userId)
                .Select(x => x.Name)
                .ToList();

            return result;
        }

        public IEnumerable<T> GetProjectsByCategoryId<T>(int categoryId)
        {
            var result = this.projectsRepository
                .All()
                .Where(x => x.ProjectCategoryId == categoryId)
                .To<T>()
                .ToList();

            return result;
        }
    }
}
