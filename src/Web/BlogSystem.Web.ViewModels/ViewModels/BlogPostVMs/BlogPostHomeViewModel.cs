using AutoMapper;
using BlogSystem.Data.Models;
using BlogSystem.Services.Mapping;
using Ganss.Xss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Web.ViewModels.ViewModels.BlogPostVMs
{
    public class BlogPostHomeViewModel : IMapFrom<BlogPost>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string HeadingImageUrl { get; set; }

        public List<string> BlogPostTags { get; set; }

        public string Content { get; set; }

        public int BlogPostReactionsCount { get; set; }

        public string SanitizedContent
            => new HtmlSanitizer().Sanitize(this.Content);

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BlogPost, BlogPostHomeViewModel>()
                .ForMember(
                    source => source.BlogPostTags,
                    destination => destination.MapFrom(member => member.BlogPostTags.Select(x => x.Text)));
        }
    }
}
