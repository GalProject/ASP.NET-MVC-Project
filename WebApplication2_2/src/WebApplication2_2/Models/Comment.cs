using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2_2.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        [Display(Name = "Comment Title")]
        [StringLength(80, MinimumLength = 2)]
        [Required]
        public string CommentTitle { get; set; }
        [Display(Name = "Comment Writer")]
        [Required]
        public string CommentWriter { get; set; }
        [Display(Name = "Comment Writer URL")]
        public string CommentWriterURL { get; set; }
        [Required]
        [Display(Name = "Comment Content")]
        public string CommentContent { get; set; }
        public virtual Post CommentPost { get; set; }

    }
}
