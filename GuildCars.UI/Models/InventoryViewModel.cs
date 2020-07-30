using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class InventoryViewModel
    {
        public Car Car { get; set; }
        public List<Car> Cars { get; set; }
        public int? CarID { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public string StockValue { get; set; }

    }
}