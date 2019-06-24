using System.Collections.Generic;
using System.Data.Entity;
using TechLib.Domain.Entities;
using TechLib.Domain.Repositories;

namespace TechLib.DataAccess.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly AppDbContext db;

        public BookRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Book> Books => db.Books;

        public void SaveBook(Book book)
        {
            if (book.BookId == 0) // create
            {
                db.Books.Add(book);
            }
            else // edit
            {
                db.Entry(book).State = EntityState.Modified;
            }

            db.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = db.Books.Find(bookId);
            if (book == null) return;

            db.Books.Remove(book);
            db.SaveChanges();
        }
    }
}
