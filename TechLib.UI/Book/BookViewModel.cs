using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLib.Domain.Entities;
using TechLib.Domain.Repositories;

namespace TechLib.UI.Book
{
    public class BookViewModel
    {
        private readonly IBookRepository bookRepository;

        public BookViewModel(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public List<BookListRow> BookList
        {
            get
            {
                var bookListRows = bookRepository.Books.AsQueryable()
                    .Select(b => new BookListRow
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        Author = b.Author.FName + " " + b.Author.LName,
                        InUse = b.ReaderId != null ? "Да" : "Нет"
                    })
                    .OrderBy(r => r.Title)
                    .ToList();
                return bookListRows;
            }
        }
    }
}
