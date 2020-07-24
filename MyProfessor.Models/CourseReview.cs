using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyProfessor.Models
{
    public class CourseReview
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string UserId { get; set; }
        [Range(1, 5)]
        public int Stars { get; set; }
        public DateTime Date { get; set; }
        [StringLength(400)]
        public string Review { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual SystemUsers User { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
