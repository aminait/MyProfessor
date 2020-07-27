using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyProfessor.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public virtual ICollection<UserCourses> Users { get; set; }
        public virtual ICollection<CourseReview> Reviews { get; set; }
    }
}
