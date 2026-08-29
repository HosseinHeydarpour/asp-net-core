using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models
{
    public class Person
    {

        [Required(ErrorMessage = "{0} cannot be empty or null")]
        [Display(Name = "Person Name")]  // you can choose whetever name for this property
        [StringLength(40, MinimumLength = 2, ErrorMessage = "{0} length has problem - it cannot be more than {1} and less than {2}!")] // 
        public string? PersonName { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
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
