using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;
using ShopAPI.BusinessLayer;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Threading;

namespace ShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopAPIController : ControllerBase
    {
        private readonly ILogger<ShopAPIController> _logger;



        public ShopAPIController(ILogger<ShopAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public IEnumerable<ViewVehicle> ImportCars()
        {
            Assembly currentAssem = Assembly.GetExecutingAssembly();
            string asstesFolder = Path.GetDirectoryName(currentAssem.Location) + "/Assets/";
            
            //Delete the database
            string dbName = "ShopDatabase.db";
            if (System.IO.File.Exists(dbName))
            {
                System.IO.File.Delete(dbName);
            }
            var dbContext = new ShopDbContext();
            dbContext.Database.EnsureCreated();


            string zipName = asstesFolder + "Warehouses.zip";
            string extractFolder = asstesFolder + "/extracted";
            Directory.CreateDirectory(extractFolder);
            WarehouseControl whControl = new WarehouseControl();

            using (ZipArchive archive = ZipFile.OpenRead(zipName))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        string extractFile = Path.Combine(extractFolder, entry.FullName);
                        entry.ExtractToFile(extractFile, true);

                        string json = System.IO.File.ReadAllText(extractFile);
                        Newtonsoft.Json.JsonSerializer s = new Newtonsoft.Json.JsonSerializer();

                        Warehouse[] warehouses = JsonConvert.DeserializeObject<Warehouse[]>(json);
                        whControl.SaveAll(warehouses);
                    }
                }
            }

            VehicleControl cControl = new VehicleControl();
            return cControl.GetAllCars();
            //return whControl.GetAllWarehouses();
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public IEnumerable<ViewVehicle> GetAllCars()
        {
            VehicleControl cControl = new VehicleControl();
            return cControl.GetAllCars();
        }
    }

}
