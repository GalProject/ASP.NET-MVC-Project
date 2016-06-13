using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2_2.Models
{
    public class Post
    {
       
        public int ID { get; set; }
        [Display(Name = "Post Title")]
        [StringLength(80, MinimumLength = 2)]
        [Required]
        public string PostTitle { get; set; }
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "Post Writer Name")]
        [Required]
        public string PostWriterName { get; set; }
        [Display(Name = "Post Writer URL")]
        public string PostWriterURL { get; set; }
        [Display(Name = "Post Date")]
        public DateTime PostDate { get; set; }
        [Required]
        [Display(Name = "Post Content")]
        public string PostContent { get; set; }
        public virtual ICollection<Comment> CommentList { get; set; }
        [Display(Name = "Post Picture")]
        public string PostPicture { get; set; }
        [Display(Name = "Post Video")]
        public string PostVideo { get; set; }

    }
}
