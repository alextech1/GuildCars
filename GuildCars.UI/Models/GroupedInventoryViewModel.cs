using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class GroupedInventoryViewModel
    {
        public List<InventoryViewModel> NewVehicles { get; set; }
        public List<InventoryViewModel> UsedVehicles { get; set; }
    }
}