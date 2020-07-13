using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("Condition")]
    public class Condition
    {
        [Key]

        public int? ConditionID { get; set; }
        public string ConditionType { get; set; }
    }
}
