using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyProfessor.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual SystemUsers Teacher { get; set; }
        public virtual ICollection<ArticleReview> Reviews { get; set; }

        [StringLength(1024)]
        public string ItemArtUrl { get; set; }
    }
}
