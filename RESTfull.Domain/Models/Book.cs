using System.ComponentModel.DataAnnotations;

namespace RESTfull.Domain
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public int AuthorId { get; set; }

        public Author? Author { get; set; }

        public int Year { get; set; }
    }
}
