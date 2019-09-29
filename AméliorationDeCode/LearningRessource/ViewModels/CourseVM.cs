using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningRessource.ViewModels
{
    public class CourseVM:IValidatableObject
    {
        [DisplayName("Titre")]
        [Required(ErrorMessage ="veuillez remplir le champ")]
        public string Title { get; set; }

        public string Description { get; set; }

        [DisplayName("Date de début")]
        [DataType(DataType.Date, ErrorMessage ="Veuillez renseigner une date valide")]
        public DateTime StartDate { get; set; }

        [DisplayName("Date de fin")]
        [DataType(DataType.Date, ErrorMessage = "Veuillez renseigner une date valide")]
        public DateTime EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (StartDate < DateTime.Now.Date)
            {
                results.Add(new ValidationResult("La date de début doit être supérieure ou égale à la date du jour", new[] { "StartDate"}));
            }
            if (EndDate <= StartDate.Date)
            {
                results.Add(new ValidationResult("La date de fin doit etre supérieure à la date de début", new[] { "EndDate"}));
            }
            return results;
        }
    }
}