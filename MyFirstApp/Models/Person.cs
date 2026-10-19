namespace MyFirstApp.Models
{

    public enum Gender
    {
        Male, Female, Other
    }

    public class Person
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Gender? PersonGender { get; set; }

    }
}
