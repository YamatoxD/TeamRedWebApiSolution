using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedProject.Enitites
{
    public class Comment
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CommentMade { get; set; }

        [ForeignKey("UserId")]
        public User Creator { get; set; }

        public int UserId { get; set; }
    }
}
