using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.BusinessLayer
{
    public class WarehouseControl
    {
        private readonly ShopDbContext _dbContext;

        public WarehouseControl()
        {
            _dbContext = new ShopDbContext();
        }

        public IEnumerable<Warehouse> GetAllWarehouses()
        {
            return (from q in _dbContext.Warehouses select q);
        }

        public void SaveAll(Warehouse[] WarehouseArr)
        {
            _dbContext.Warehouses.AddRange(WarehouseArr);
            _dbContext.SaveChanges();

            //Fill the Foreign Keys
            foreach (Warehouse w in WarehouseArr)
            {
                w.Cars.WarehouseID = w._ID;
                w.Location.WarehouseID = w._ID;
                foreach(Vehicle v in w.Cars.Vehicles)
                {
                    v.CarID = w.Cars._ID;
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
