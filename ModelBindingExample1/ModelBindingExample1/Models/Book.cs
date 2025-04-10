using Microsoft.AspNetCore.Mvc;

namespace ModelBindingExample1.Models
{
    public class Book
    {
       // [FromQuery]
        public int? BookId { get; set; } 
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book id {BookId} and Author is {Author}";
        }
    }
}
