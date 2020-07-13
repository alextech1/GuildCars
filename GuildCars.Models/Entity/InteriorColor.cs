using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("InteriorColor")]
    public class InteriorColor
    {
        [Key]
        public int? InteriorColorID { get; set; }
        public string Color { get; set; }
    }
}
