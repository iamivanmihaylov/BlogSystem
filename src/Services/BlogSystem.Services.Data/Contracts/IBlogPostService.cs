using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Services.Data.Contracts
{
    public interface IBlogPostService
    {
        Task CreateBlogPostAsync(string userId, string title, List<string> tags, string content, string headingImageUrl);

        Task<List<T>> GetAllBlogPostsAsync<T>(int page = 0);
    }
}
