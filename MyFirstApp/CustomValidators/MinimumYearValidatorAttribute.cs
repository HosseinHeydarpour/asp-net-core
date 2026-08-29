using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.CustomValidators
{

    // we must do this ---> : ValidationAttribute
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {

        public int MinimumYear { get; set; } = 2000; // default is 2000 in case nothing is set
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";

        // Paramaterless constructor
        public MinimumYearValidatorAttribute()
        {

        }

        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear)
                {
                    // In order to string formatting start working in model class
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                } else
                {
                    // WHEN YEAR IS LESS THAn 2000
                    return ValidationResult.Success;
                }
            }

            // No validation 
            return null;
        }
    }
}
