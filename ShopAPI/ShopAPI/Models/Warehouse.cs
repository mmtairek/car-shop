using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Warehouse
    {
        public Warehouse()
        {
            //cars = new HashSet<Car>();
        }

        [Key]
        public int _ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Location Location { get; set; }        
        public Car Cars { get; set; }
    }
}
