using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("Specials")]
    public class Specials
    {
        [Key]
        public int? SpecialsID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
    }
}
