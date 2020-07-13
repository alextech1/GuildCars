using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class CarViewModel
    {
        public Car CarVM { get; set; }
        public List<Car> Cars { get; set; }
        public int CarVMID { get; set; }
        public Make Make { get; set; }
        public string MakeName { get; set; }
        public Model Model { get; set; }
        public string ModelName { get; set; }
        public bool OnSale { get; set; }
        public int Year { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public string BodyStyleName { get; set; }
        public Transmission Transmission { get; set; }
        public string TransmissionType { get; set; }
        public ExteriorColor ExteriorColor { get; set; }
        public string ExteriorColorName { get; set; }
        public InteriorColor InteriorColor { get; set; }
        public string InteriorColorName { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string ImageFileName { get; set; }
        public string Description { get; set; }
        public int Role { get; set; }
        public IGuildRepository IGuildRepository { get; set; }

        public CarViewModel()
        {
            
        }
    }

    

}