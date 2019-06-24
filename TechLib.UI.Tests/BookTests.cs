using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechLib.DataAccess;
using TechLib.DataAccess.Repositories;
using TechLib.UI.Book;

namespace TechLib.UI.Tests
{
    [TestClass]
    public class BookTests
    {
        private readonly BookViewModel bookViewModel;

        public BookTests()
        {
            bookViewModel = new BookViewModel(new BookRepository(new AppDbContext()));
        }

        [TestMethod]
        public void CanGetBookList()
        {
            var bookListRows = bookViewModel.BookList;

            Assert.IsNotNull(bookListRows);
            Assert.IsInstanceOfType(bookListRows.FirstOrDefault(), typeof(BookListRow));
        }
    }
}
