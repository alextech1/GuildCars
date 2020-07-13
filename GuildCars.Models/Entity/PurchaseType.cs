using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("PurchaseType")]
    public class PurchaseType
    {
        [Key]
        public int? PurchaseTypeID { get; set; }
        public string PurchaseTypeName { get; set; }
    }
}
