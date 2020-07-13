using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        public string UserID { get; set; }
        public bool OnSale { get; set; }
        public bool IsInStock { get; set; }
        public int? MakeID { get; set; }
        [ForeignKey("MakeID")]
        public virtual Make Make { get; set; }
        public List<Make> Makes { get; set; }
        public int? ModelID { get; set; }
        [ForeignKey("ModelID")]
        public virtual Model Model { get; set; }
        public List<Model> Models { get; set; }
        public int? ConditionID { get; set; }
        [ForeignKey("ConditionID")]
        public virtual Condition Condition { get; set; }
        public List<Condition> Conditions { get; set; }
        public int Year { get; set; }
        public int? BodyStyleID { get; set; }
        [ForeignKey("BodyStyleID")]
        public virtual BodyStyle BodyStyle { get; set; }
        public List<BodyStyle> BodyStyles { get; set; }
        public int? TransmissionID { get; set; }
        [ForeignKey("TransmissionID")]
        public virtual Transmission Transmission { get; set; }
        public List<Transmission> Transmissions { get; set; }
        public int? ExteriorColorID { get; set; }
        [ForeignKey("ExteriorColorID")]
        public virtual ExteriorColor ExteriorColor { get; set; }
        public List<ExteriorColor> ExteriorColors { get; set; }
        public int? InteriorColorID { get; set; }
        [ForeignKey("InteriorColorID")]
        public virtual InteriorColor InteriorColor { get; set; }            
        public List<InteriorColor> InteriorColors { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public string DateAdded { get; set; }
        public string Photo { get; set; }
    }
}
