namespace RESTfull.Domain
{
    public class Author
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();

        public Author(string? name, string? description)
        {
            Name = name;
            Description = description;
        }

        public Author(AuthorDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
        }
    }
}