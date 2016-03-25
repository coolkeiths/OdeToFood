using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{

    public class CustomValidator : ValidationAttribute 
    {
        private readonly int _maxWords;

        public CustomValidator(int maxWords) : base ("{0} has too many words")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errormessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errormessage);
                }
            }

            return ValidationResult.Success;
        }


    }

    public class RestaurantReview
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        [Required]
        [Range(1,10)]
        public int Rating { get; set; }

        [Display(Name="User Name")]
        [DisplayFormat(NullDisplayText="Anonymous")]
        [CustomValidator(1)]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
    }
}