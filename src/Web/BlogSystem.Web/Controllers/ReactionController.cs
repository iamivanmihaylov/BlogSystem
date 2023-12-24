namespace BlogSystem.Web.Controllers
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    using BlogSystem.Data.Models;
    using BlogSystem.Services.Data.Contracts;
    using BlogSystem.Web.ViewModels.DTOs.ReactionDTOs;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionService reactionService;

        public ReactionController(IReactionService reactionService)
        {
            this.reactionService = reactionService;
        }

        [HttpPost]
        public async Task<ActionResult<ReactionResponseDTO>> Post(ReactionInputDTO reactionDTO)
        {
            var isSessionFound = this.Request.Cookies.TryGetValue("Session", out var session);
            if (!isSessionFound)
            {
                this.Response.Cookies.Append("Session", Guid.NewGuid().ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(30),
                    Path = "/",
                    Secure = true,
                });
            }

            var reaction = this.reactionService.GetReaction(reactionDTO.BlogPostId, session);

            if (reaction is null)
            {
                await this.reactionService.ReactAsync(reactionDTO.BlogPostId, reactionDTO.ReactionType, session);
            }
            else
            {
                await this.reactionService.UpdateReactionAsync(reactionDTO.BlogPostId, session, reactionDTO.ReactionType);
            }

            var reactionsCount = this.reactionService.GetReactsCount(reactionDTO.BlogPostId, reactionDTO.ReactionType);

            return this.Ok(new ReactionResponseDTO
            {
                BlogPostId = reactionDTO.BlogPostId,
                ReactionType = reactionDTO.ReactionType,
                ReactionCount = reactionsCount,
            });
        }
    }
}
