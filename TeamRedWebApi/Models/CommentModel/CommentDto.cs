using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedWebApi.Models.CommentModel
{
#pragma warning disable CS1591
    public class CommentDto
    {
        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
