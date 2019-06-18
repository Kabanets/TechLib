using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLib.Domain.Entities;

namespace TechLib.DataAccess
{
    public class AppDbInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            //Authors
            //if (!context.Authors.Any())
            //{
            //    context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (Authors, RESEED, 0)");
            //}

            var authors = new List<Author>();
            for (int i = 1; i <= 50; i++)
            {
                var author = new Author
                {
                    AuthorId = i,
                    FName = $"FName-{i}",
                    LName = $"LName-{i}"
                };
                authors.Add(author);
            }

            context.Authors.AddOrUpdate(authors.ToArray());

            //Readers
            var readers = new List<Reader>();
            for (int i = 1; i <= 100; i++)
            {
                var reader = new Reader
                {
                    ReaderId = i,
                    FName = $"FName-{i}",
                    LName = $"LName-{i}"
                };
                readers.Add(reader);
            }

            context.Readers.AddOrUpdate(readers.ToArray());

            //Books
            Random rand = new Random();
            var books = new List<Book>();
            for (int i = 1; i <= 500; i++)
            {
                var book = new Book
                {
                    BookId = i,
                    Title = $"Title-{i}",
                    Description = $"Description-{i}",
                    AuthorId = rand.Next(1, 50),
                    ReaderId = i <= 100 ? rand.Next(1, 100) : (int?)null
                };

                books.Add(book);
            }

            context.Books.AddOrUpdate(books.ToArray());
        }
    }
}
