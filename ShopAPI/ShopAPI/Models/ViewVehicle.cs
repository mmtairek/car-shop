using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class ViewVehicle
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Warehouse { get; set; }
        public string Location { get; set; }
        public float? Price { get; set; }
        public string Currency { get; set; }
        public DateTime? AddedDate { get; set; }
        public Boolean IsLicensed { get; set; }
    }
}
