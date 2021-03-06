﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ReportsViewModel
    {
        public string ID { get; set; }
        public string User { get; set; }
        public UserListViewModel UserListViewModel { get; set; }
        public IEnumerable<UserListViewModel> Users { get; set; }
        public int? UsersID { get; set; }
        public IEnumerable<ReportsViewModel> Reports { get; set; }
        public string TotalSales { get; set; }
        public string TotalVehicles { get; set; }
    }
}