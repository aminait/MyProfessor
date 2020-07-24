using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProfessor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProfessor.DataAccess
{
    public class DiscDbContext:IdentityDbContext<SystemUsers>
    {
        public DiscDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<UserCourses> UserCourses { get; set; }
        public DbSet<ArticleReview> ArticleReview { get; set; }
        public DbSet<CourseReview> CourseReview { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
