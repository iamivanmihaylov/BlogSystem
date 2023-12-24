namespace BlogSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BlogSystem.Data.Common.Repositories;
    using BlogSystem.Data.Models;
    using BlogSystem.Services.Data.Contracts;
    using BlogSystem.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class BlogPostService : IBlogPostService
    {
        private readonly IDeletableEntityRepository<BlogPost> blogPostRepository;
        private readonly IDeletableEntityRepository<BlogPostTag> blogPostTagRepository;

        public BlogPostService(IDeletableEntityRepository<BlogPost> blogPostRepository,
            IDeletableEntityRepository<BlogPostTag> blogPostTagRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostTagRepository = blogPostTagRepository;
        }

        public async Task CreateBlogPostAsync(string userId, string title, List<string> tags, string content, string headingImageUrl)
        {
            // TODO: Refactor with merge here
            var existingTags = await this.blogPostTagRepository
                .All()
                .Where(existingTag => tags.Contains(existingTag.Text))
                .ToListAsync();

            var newTags = tags
                .Where(newlyAddedTag => !existingTags.Any(existingTag => existingTag.Text == newlyAddedTag))
                .Select(tagText => new BlogPostTag
                {
                    Text = tagText,
                })
                .ToList();

            var tagsToAdd = new List<BlogPostTag>();
            tagsToAdd.AddRange(existingTags);
            tagsToAdd.AddRange(newTags);

            var blogPost = new BlogPost
            {
                Title = title,
                Content = content,
                HeadingImageUrl = headingImageUrl,
                BlogPostTags = tagsToAdd,
                UserId = userId,
            };

            await this.blogPostRepository.AddAsync(blogPost);
            await this.blogPostRepository.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllBlogPostsAsync<T>(int page = 0)
        {
            // TODO: Add pagination
            var blogPosts = await this.blogPostRepository
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToListAsync();

            return blogPosts;
        }
    }
}
