using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("State")]
    public class State
    {
        [Key]
        public int? StateID { get; set; }
        public string StateAbbr { get; set; }
        public string StateName { get; set; }

    }
}
