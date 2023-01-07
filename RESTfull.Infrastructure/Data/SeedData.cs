using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RESTfull.Infrastructure;

namespace RESTfull.Domain.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>())) {
                if (context.Authors.Any()) {
                    return;   // БД уже была заполнена ранее
                }

                Author author_1 = new Author { Name = "Herbert Schildt" };
                Author author_2 = new Author { Name = "Robert Martin" };
                Author author_3 = new Author { Name = "Mark J. Price" };

                context.Authors.AddRange(author_1, author_2, author_3);

                context.Books.AddRange(
                    new Book
                    {
                        Name = "Java. A Beginner's Guide",
                        Author = author_1,
                        AuthorId = 1,
                        Year = 2002
                    },
                    new Book
                    {
                        Name = "Java 8",
                        Author = author_1,
                        AuthorId = 1,
                        Year = 2014
                    },
                    new Book
                    {
                        Name = "Clean Code",
                        Author = author_2,
                        AuthorId = 2,
                        Year = 2008
                    },
                    new Book
                    {
                        Name = "C# 8.0 and .NET Core 3.0",
                        Author = author_3,
                        AuthorId = 3,
                        Year = 2000
                    });
                context.SaveChanges();
            }
        }
    }
}
