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
            if(value != null)
            {
                // Get to datea
                DateTime toDate = Convert.ToDateTime(value);



            

                // Using reflection - get from date
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (otherProperty != null)
                {
                    // ObjectInstance refers to the model object
                    DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));


                    if (fromDate > toDate)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                    } else
                    {
                        return ValidationResult.Success;
                    }
                } 

                 
            }

            return null;
        }
    }
}
