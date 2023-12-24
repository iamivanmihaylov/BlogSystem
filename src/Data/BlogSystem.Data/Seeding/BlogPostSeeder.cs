using BlogSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace BlogSystem.Data.Seeding
{
    public class BlogPostSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BlogPosts.Any())
            {
                return;
            }

            var fakerForTags = new Faker<BlogPostTag>()
                .RuleFor(t => t.Text, f => f.Lorem.Word());

            var faker = new Faker<BlogPost>()
                .RuleFor(t => t.Title, f => f.Lorem.Text())
                .RuleFor(hi => hi.HeadingImageUrl, f => f.Image.PicsumUrl(500, 300))
                .RuleFor(c => c.Content, f => f.Lorem.Paragraph())
                .RuleFor(bpt => bpt.BlogPostTags, f => fakerForTags.Generate(f.Random.Number(1, 5)));

            var fakeBlogPosts = faker.Generate(20);

            await dbContext.AddRangeAsync(fakeBlogPosts);
            await dbContext.SaveChangesAsync();
        }
    }
}
