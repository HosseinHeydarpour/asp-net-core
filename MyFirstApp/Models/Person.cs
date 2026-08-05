namespace MyFirstApp.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        // Question mark says we can accept null values
        public string? FirstName { get; set; }

        // Question mark says we can accept null values
        public string? LastName { get; set; }

        public int Age { get; set; }


    }
}
