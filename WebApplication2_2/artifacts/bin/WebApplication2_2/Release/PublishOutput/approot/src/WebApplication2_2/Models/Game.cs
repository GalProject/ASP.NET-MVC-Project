using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2_2.Models
{
    public class Game
    {

        public int ID { get; set; }

        [Display(Name = "Game Name")]
        [StringLength(80, MinimumLength = 2)]
        [Required]
        public string GameName { get; set; }
        [Display(Name = "Game Date")]
        [DataType(DataType.Date)]
        public DateTime GameDate { get; set; }
        [Display(Name = "Game Price")]
        [Range(1, 1000)]
        public Decimal GamePrice { get; set; }
        [Display(Name = "Genre")]
        public string GameGenre { get; set; }
        [Display(Name = "Availability")]
        public string GameAvailability { get; set; }
        [Display(Name = "Game Video")]
        public string GameVideo { get; set; }
        public int PostID { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        [Display(Name = "Game Content")]
        [Required]
        public string GameContent { get; set; }
        [Display(Name = "Game Pic")]
        public string GamePic { get; set; }
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "Game Developers")]
        public string GameDevelopers { get; set; }
    }
}
