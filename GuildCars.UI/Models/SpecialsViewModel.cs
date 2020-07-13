using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SpecialsViewModel
    {
        public Specials Specials { get; set; }
        public List<Specials> SpecialsList { get; set; }
        public int? SpecialsID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
    }
}