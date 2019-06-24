using System.Collections.Generic;
using TechLib.Domain.Entities;

namespace TechLib.Domain.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        void SaveBook(Book book);
        void DeleteBook(int bookId);
    }
}
