using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models
{
    public class Person
    {

        [Required(ErrorMessage = "{0} cannot be empty or null")]
        [Display(Name = "Person Name")]  // you can choose whetever name for this property
        [StringLength(40, MinimumLength = 2, ErrorMessage = "{0} length has problem - it cannot be more than {1} and less than {2}!")] // 
        [RegularExpression(@"^[A-Za-z][A-Za-z .]*$", ErrorMessage ="Invalid {0} - should contain only alphabets, space and dot(.)")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage ="The email provided is not valid! - example@example.com")]
        [Required(ErrorMessage = "Email cannot be blank... Please provide one")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} is not in a correct format... - it should contain 10 digits")]
        [ValidateNever] //  when we want to disable validation on a property temporarly we can do this 
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [Compare("Password", ErrorMessage ="{0} and {1} are not the same - check it please ")]  // 0 is current property and 1 is the prop we are comparing cueent prop with it
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
        public double? Price { get; set; }



        public override string ToString()
        {
            string maskedPassword = string.IsNullOrEmpty(Password) ? "N/A" : "********";
            string maskedConfirmPassword = string.IsNullOrEmpty(ConfirmPassword) ? "N/A" : "********";

           return $"""
           Person Details:
           -----------------------
             Name:             {PersonName ?? "N/A"}
             Email:            {Email ?? "N/A"}
             Phone:            {Phone ?? "N/A"}
             Price:            {(Price.HasValue ? Price.Value.ToString("C") : "N/A")}
             Password:         {maskedPassword}
             Confirm Password: {maskedConfirmPassword}
           """;
        }
    }
}
