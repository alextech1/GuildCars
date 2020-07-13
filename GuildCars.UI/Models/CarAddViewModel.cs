using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class CarAddViewModel
    {
        public Car Car { get; set; }
        public int CarID { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public int? MakesID { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public int? ModelsID { get; set; }
        public IEnumerable<Condition> Types { get; set; }
        public int? TypesID { get; set; }
        public IEnumerable<BodyStyle> BodyStyles { get; set; }
        public int? BodyStylesID { get; set; }
        public int? Year { get; set; }
        public IEnumerable<Transmission> Transmissions { get; set; }
        public int? TransmissionsID { get; set; }
        public IEnumerable<ExteriorColor> ExteriorColors { get; set; }
        public int? ExteriorColorsID { get; set; }
        public IEnumerable<InteriorColor> InteriorColors { get; set; }
        public int? InteriorColorsID { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public decimal? MSRP { get; set; }
        public decimal? SalePrice { get; set; }
        public string Description { get; set; }
        public string DateAdded { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public CarAddViewModel()
        {

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Car.MakeID <= 0 || Car.MakeID == null)
            {
                errors.Add(new ValidationResult("Make is required"));
            }

            if (Car.ModelID <= 0 || Car.ModelID == null)
            {
                errors.Add(new ValidationResult("Model is required"));
            }

            if (Car.ConditionID <= 0 || Car.ConditionID == null)
            {
                errors.Add(new ValidationResult("Condition is required"));
            }

            if (Car.BodyStyleID <= 0 || Car.BodyStyleID == null)
            {
                errors.Add(new ValidationResult("BodyStyle is required"));
            }

            if (Car.Year <= 1940)
            {
                errors.Add(new ValidationResult("Valid year is required"));
            }

            if (Car.TransmissionID <= 0 || Car.MakeID == null)
            {
                errors.Add(new ValidationResult("Transmission is required"));
            }
            if (Car.ExteriorColorID <= 0 || Car.MakeID == null)
            {
                errors.Add(new ValidationResult("ExteriorColor is required"));
            }

            if (Car.InteriorColorID <= 0 || Car.InteriorColorID == null)
            {
                errors.Add(new ValidationResult("InteriorColor is required"));
            }

            if (string.IsNullOrEmpty(Car.Mileage))
            {
                errors.Add(new ValidationResult("Mileage is required"));
            }

            if (string.IsNullOrEmpty(Car.VIN))
            {
                errors.Add(new ValidationResult("VIN is required"));
            }
            if (Car.MSRP <= 0)
            {
                errors.Add(new ValidationResult("MSRP is required"));
            }

            if (Car.SalePrice <= 0)
            {
                errors.Add(new ValidationResult("SalePrice is required"));
            }

            if (string.IsNullOrEmpty(Car.Description))
            {
                errors.Add(new ValidationResult("Description is required"));
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg."));
                }
            }
            else
            {
                errors.Add(new ValidationResult("Image file is required"));
            }

            return errors;
        }
    }
}