using System.Text.Json.Serialization;

namespace RESTfull.Domain
{
    public class BookDTO
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public int? Year { get; set; }

        public string? Description { get; set; }

        public int? AuthorId { get; set; }

        [JsonConstructor]
        public BookDTO(string? name, int? year, string? description, int? authorId)
        {
            Name = name;
            Year = year;
            Description = description;
            AuthorId = authorId;
        }

        public BookDTO(int? id, string? name, int? year, string? description, int? authorId)
        {
            Id = id;
            Name = name;
            Year = year;
            Description = description;
            AuthorId = authorId;
        }

        public BookDTO(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Year = book.Year;
            Description = book.Description;
            AuthorId = book.AuthorId;
        }
    }
}
