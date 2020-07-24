using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyProfessor.Models
{
    public class UserCourses
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public SystemUsers User { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
