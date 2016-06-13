using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2_2.Models
{
    public class Store
    {
        public int ID { get; set; }
        [Display(Name = "Name Of Store")]
        public string NameOfStore { get; set; }
        [Display(Name = "Latitude Of Store")]
        public Double LatitudeOfStore { get; set; }
        [Display(Name = "Longitude Of Store")]
        public Double LongitudeOfStore { get; set; }
    }
}
