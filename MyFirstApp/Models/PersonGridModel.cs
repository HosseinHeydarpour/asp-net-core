namespace MyFirstApp.Models
{
    public class PersonGridModel
    {
        public string GridTitle { get; set; } = "";

        public List<Person> PersonList { get; set; } = new List<Person>(); 
    }
}
