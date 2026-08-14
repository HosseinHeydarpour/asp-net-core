using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models
{
    public class Person
    {

        [Required]
        public string? PersonName { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
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
