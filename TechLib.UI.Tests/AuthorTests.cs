using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TechLib.DataAccess;
using TechLib.DataAccess.Repositories;
using TechLib.UI.Author;

namespace TechLib.UI.Tests
{
    [TestClass]
    public class AuthorTests
    {
        private readonly AuthorViewModel authorViewModel;

        public AuthorTests()
        {
            authorViewModel = new AuthorViewModel(new AuthorRepository(new AppDbContext()));
        }

        [TestMethod]
        public void CanGetAuthorList()
        {
            var authors = authorViewModel.AuthorList;

            Assert.IsNotNull(authors);
            Assert.IsInstanceOfType(authors.FirstOrDefault(), typeof(Domain.Entities.Author));
        }
    }
}
