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
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DisplayName("End date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (StartDate < DateTime.Now.Date)
            {
                results.Add(new ValidationResult("Start date  must be greater than or equal to current time", new[] { "StartDate"}));
            }
            if (EndDate <= StartDate.Date)
            {
                results.Add(new ValidationResult("End Date must be greater that Start Date", new[] { "EndDate"}));
            }
            return results;
        }
    }
}