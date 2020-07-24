using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProfessor.Models
{
    public class SystemUsers:IdentityUser
    {
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<ArticleReview> ArticleReviews { get; set; }
        public virtual ICollection<UserCourses> Course { get; set; }
        public virtual ICollection<CourseReview> CourseReviews { get; set; }
    }
}
