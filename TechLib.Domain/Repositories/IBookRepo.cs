using System.Collections.Generic;
using TechLib.Domain.Entities;

namespace TechLib.Domain.Repositories
{
    public interface IBookRepo
    {
        IEnumerable<Book> Books { get; }
        void SaveBook(Book book);
        void DeleteBook(int bookId);
    }
}
