using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Models
{
    public class Book
    {
        // [FromQuery]
        public int? BookId { get; set; } // BookId will be set from query string and not route data

        // [FromRoute]
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book Object - Book id: {BookId}, Author: {Author}";
        }

    }
}
