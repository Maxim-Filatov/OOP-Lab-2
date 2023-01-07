using System.ComponentModel.DataAnnotations;

namespace RESTfull.Domain
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}