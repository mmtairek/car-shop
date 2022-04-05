using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    /// <summary>
    /// Car entity
    /// </summary> 
    public class Car
    {
        public Car()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int _ID { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public int WarehouseID { get; set; }
    }
}
