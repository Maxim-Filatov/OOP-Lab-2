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

                context.Authors.AddRange(
                    new Author("Herbert Schildt", "American computing author, programmer and musician"),
                    new Author("Robert Martin", "American software engineer, instructor, and best-selling author"),
                    new Author("Mark J. Price", "Passionate educator of C#, .NET, and modern cross-platform development"));

                context.Books.AddRange(
                    new Book("Java. A Beginner's Guide", 1, 2002, "Fully updated for Java Platform, Standard Edition 11"),
                    new Book("Java 8", 1, 2014, "The Definitive Java Programming Guide"),
                    new Book("Clean Code", 2, 2008, "Handbook of Agile Software Craftsmanship"),
                    new Book("C# 8.0 and .NET Core 3.0", 3, 2000, "Modern Cross-Platform Development"));

                context.SaveChanges();
            }
        }
    }
}
