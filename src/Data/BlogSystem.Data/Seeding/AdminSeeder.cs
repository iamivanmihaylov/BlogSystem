namespace BlogSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlogSystem.Common;
    using BlogSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var dbHasUsers = userManager.Users.Any();

            if (!dbHasUsers)
            {
                var adminUser = new ApplicationUser
                {
                    Id = "cdfc2091-dd65-46f2-a92d-1b32746e1f89",
                    Email = "ivan4o03.it@gmail.com",
                    PhoneNumber = "0885222962",
                    UserName = "ivan4o03",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true,
                };

                await userManager.CreateAsync(adminUser, "123456");
                await userManager.AddToRoleAsync(adminUser, GlobalConstants.AdministratorRoleName);
            }
        }
    }
}
