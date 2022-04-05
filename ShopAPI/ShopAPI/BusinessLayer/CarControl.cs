using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.BusinessLayer
{
    public class VehicleControl
    {
        private readonly ShopDbContext _dbContext;

        public VehicleControl()
        {
            _dbContext = new ShopDbContext();
        }

        public IEnumerable<ViewVehicle> GetAllVehicles()
        {
            return (
                    from v in _dbContext.Vehicles
                    join c in _dbContext.Cars on v.CarID equals c._ID
                    join w in _dbContext.Warehouses on c.WarehouseID equals w._ID
                    orderby v.Date_added descending
                    select new ViewVehicle { 
                        ID = v._ID,
                        Model = v.Model,
                        Make = v.Make,
                        Year = v.Year_model,
                        Warehouse = w.Name,
                        Location = c.Location,
                        Price = v.Price,
                        Currency = "USD",
                        AddedDate = v.Date_added,
                        IsLicensed = v.Licensed
                    }
                );
        }
    }
}
