using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("BodyStyle")]
    public class BodyStyle
    {
        [Key]
        public int? BodyStyleID { get; set; }
        public string BodyStyleName { get; set; }
    }
}
