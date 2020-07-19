using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ModelsViewModel
    {
        public Make Make { get; set; }
        public List<Make> Makes { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string DateAdded { get; set; }
        public string User { get; set; }
    }
}