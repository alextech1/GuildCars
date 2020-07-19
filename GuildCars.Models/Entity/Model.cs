using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("Model")]
    public class Model
    {
        [Key]
        public int? ModelID { get; set; }
        public int? MakeID { get; set; }
        [ForeignKey("MakeID")]
        public virtual Make Make { get; set; }               
        public string ModelName { get; set; }
        public string UserID { get; set; }
        public string DateAdded { get; set; }
    }
}
