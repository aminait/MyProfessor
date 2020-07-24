using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyProfessor.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CommentData { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual SystemUsers User { get; set; }
    }
}
