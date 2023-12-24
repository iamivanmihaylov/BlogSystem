using BlogSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Services.Data.Contracts
{
    public interface IReactionService
    {
        public Task ReactAsync(int blogPostId, ReactionType reactionType, string session);

        public ReactionType? GetReaction(int blogPostId, string session);

        public Task UpdateReactionAsync(int blogPostId, string session, ReactionType reactionType);

        int GetReactsCount(int blogPostId, ReactionType reactionType);
    }

}
