namespace RESTfull.Domain
{
    public class Book
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public int? AuthorId { get; set; }

        public int? Year { get; set; }

        public string? Description { get; set; }

        public Author? Author { get; set; }

        public Book(string? name, int? authorId, int? year, string? description)
        {
            Name = name;
            AuthorId = authorId;
            Year = year;
            Description = description;
        }

        public Book(BookDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            AuthorId = dto.AuthorId;
            Year = dto.Year;
            Description = dto.Description;
        }
    }
}
