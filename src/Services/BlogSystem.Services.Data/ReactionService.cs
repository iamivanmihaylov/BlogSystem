using BlogSystem.Data.Common.Repositories;
using BlogSystem.Data.Models;
using BlogSystem.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Services.Data
{
    public class ReactionService : IReactionService
    {
        private readonly IDeletableEntityRepository<BlogPostReaction> blogPostReactionRepository;

        public ReactionService(IDeletableEntityRepository<BlogPostReaction> blogPostReactionRepository)
        {
            this.blogPostReactionRepository = blogPostReactionRepository;
        }

        public ReactionType? GetReaction(int blogPostId, string session)
        {
            var result = this.blogPostReactionRepository.All().FirstOrDefault(x => x.BlogPostId == blogPostId && x.Session == session)?.ReactionType;

            return result;
        }

        public int GetReactsCount(int blogPostId, ReactionType reactionType)
        {
            return this.blogPostReactionRepository
                .All()
                .Count(x => x.BlogPostId == blogPostId && x.ReactionType == reactionType);
        }

        public async Task ReactAsync(int blogPostId, ReactionType reactionType, string session)
        {
            var reaction = new BlogPostReaction
            {
                BlogPostId = blogPostId,
                ReactionType = reactionType,
                Session = session,
            };

            await this.blogPostReactionRepository.AddAsync(reaction);
            await this.blogPostReactionRepository.SaveChangesAsync();
        }

        public async Task UpdateReactionAsync(int blogPostId, string session, ReactionType reactionType)
        {
            var blogPost = await this.blogPostReactionRepository
                .All()
                .FirstOrDefaultAsync(x => x.BlogPostId == blogPostId && x.Session == session);

            blogPost.ReactionType = reactionType;

            this.blogPostReactionRepository.Update(blogPost);
            await this.blogPostReactionRepository.SaveChangesAsync();
        }

        // public Task UpdateReactionAsync(int blogPostId, ReactionType reactionType)
        // {
        //     var blogPost = this.blogPostReactionRepository.All().FirstOrDefaultAsync(x => x)
        //     this.blogPostReactionRepository.
        // }
    }
}
