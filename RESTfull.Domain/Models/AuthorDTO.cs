using System.Text.Json.Serialization;

namespace RESTfull.Domain
{
    public class AuthorDTO
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        [JsonConstructor]
        public AuthorDTO(string? name, string? description)
        {
            Name = name;
            Description = description;
        }

        public AuthorDTO(int? id, string? name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public AuthorDTO(Author author)
        {
            Id = author.Id;
            Name = author.Name;
            Description = author.Description;
        }
    }
}