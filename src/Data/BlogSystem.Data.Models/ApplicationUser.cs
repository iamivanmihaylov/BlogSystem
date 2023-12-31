﻿// ReSharper disable VirtualMemberCallInConstructor
namespace BlogSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    using BlogSystem.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.BlogPosts = new HashSet<BlogPost>();
            this.ProjectsCategories = new HashSet<ProjectCategory>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string LinkedInProfileUrl { get; set; }

        public string InstagramProfileUrl { get; set; }

        public string FacebookProfileUrl { get; set; }

        public string GithubProfileUrl { get; set; }


        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }

        public virtual ICollection<ProjectCategory> ProjectsCategories { get; set; }
    }
}
