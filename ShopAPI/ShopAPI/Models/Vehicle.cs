using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Vehicle
    {
        [Key]
        public int _ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Make { get; set; }
        [Required]
        [MaxLength(128)]
        public string Model { get; set; }
        [Required]
        public int Year_model { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public Boolean Licensed { get; set; }
        public int CarID { get; set; }
        [Required]
        public DateTime Date_added { get; set; }
    }
}
