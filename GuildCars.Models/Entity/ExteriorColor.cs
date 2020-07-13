using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("ExteriorColor")]
    public class ExteriorColor
    {
        [Key]
        public int? ExteriorColorID { get; set; }
        public string Color { get; set; }
    }
}
