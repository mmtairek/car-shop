using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Location
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int _ID { get; set; }
        [Required]
        public float _Lat { get; set; }
        [Required]
        public float Long { get; set; }
        public int WarehouseID { get; set; }
    }
}
