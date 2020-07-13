using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class GroupedUserViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<UserViewModel> Admins { get; set; }
    }
}