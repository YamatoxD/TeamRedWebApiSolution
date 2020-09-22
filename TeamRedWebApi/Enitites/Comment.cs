﻿using System;
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

        [Required]
        [ForeignKey("RealEstateId")]
        public RealEstate RealEstate { get; set; }

        public int RealEstateId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User Creator { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("CommentId")]
        public Comment Commented { get; set; }

        public int CommentId { get; set; }


    }
}
