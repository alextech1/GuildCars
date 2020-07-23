using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ModelsViewModel
    {
        public Model Model { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public int? ModelsID { get; set; }
        public List<ModelsViewModel> ModelsVM { get; set; }
        public Make Make { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public int? MakesID { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string DateAdded { get; set; }
        public string User { get; set; }

        public ModelsViewModel()
        {

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Model.MakeID <= 0 || Model.MakeID == null)
            {
                errors.Add(new ValidationResult("Model is required"));
            }

            return errors;
        }

    }
}