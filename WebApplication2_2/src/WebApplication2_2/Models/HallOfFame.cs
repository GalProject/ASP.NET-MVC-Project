using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2_2.Models
{

    public class HallOfFame
    {
       
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Years")]
        [Range(0,120)]
        public int NumOfYearsInClub { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
    }
}
