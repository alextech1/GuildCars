using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("Make")]
    public class Make
    {
        [Key]
        public int? MakeID { get; set; }
        public string MakeName { get; set; }
    }
}
