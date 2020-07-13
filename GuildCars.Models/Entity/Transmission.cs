using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("Transmission")]
    public class Transmission
    {
        [Key]
        public int? TransmissionID { get; set; }
        public string TransmissionType { get; set; }
    }
}
