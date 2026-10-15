using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MyFirstApp.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {

        public string OtherPropertyName { get; set; }

        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // FIX: if ToDate is not supplied there is nothing to compare -> validation passes.
            // Returning plain null here makes ASP.NET Core treat the field as INVALID.
            if (value == null)
            {
                return ValidationResult.Success;
            }

            // Get to date
            DateTime toDate = Convert.ToDateTime(value);

            // Using reflection - get from date
            PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

            if (otherProperty == null)
            {
                return ValidationResult.Success;
            }

            // ObjectInstance refers to the model object
            object? rawFromDate = otherProperty.GetValue(validationContext.ObjectInstance);

            // If FromDate was not bound, skip the cross-field check
            if (rawFromDate == null)
            {
                return ValidationResult.Success;
            }

            DateTime fromDate = Convert.ToDateTime(rawFromDate);

            if (fromDate > toDate)
            {
                return new ValidationResult(
                    ErrorMessage ?? $"'{OtherPropertyName}' should be older than or equal to '{validationContext.MemberName}'",
                    new[] { OtherPropertyName, validationContext.MemberName! });
            }

            return ValidationResult.Success;
        }
    }
}
