using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechLib.DataAccess.Repositories;
using TechLib.Domain.Entities;
using TechLib.Domain.Repositories;

namespace TechLib.DataAccess.Tests.Repositories
{
    [TestClass]
    public class AuthorRepoTests
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorRepoTests()
        {
            authorRepository = new AuthorRepository(new AppDbContext());
        }

        [TestMethod]
        public void CanCreateAuthor()
        {
            var author = new Author
            {
                FName = "FName1",
                LName = "LName1"
            };

            authorRepository.SaveAuthor(author);

            var autorCreated = authorRepository.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName1" && a.LName == "LName1");
            Assert.IsNotNull(autorCreated);

            authorRepository.DeleteAuthor(author.AuthorId);
        }

        [TestMethod]
        public void CanEditAuthor()
        {
            var author = new Author
            {
                FName = "FName1",
                LName = "LName1"
            };

            authorRepository.SaveAuthor(author);

            author = authorRepository.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName1");
            Assert.IsNotNull(author);

            author.FName = "FName2";
            author.LName = "LName2";

            authorRepository.SaveAuthor(author);

            var authorEdited = authorRepository.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName2" && a.LName == "LName2");
            Assert.IsNotNull(authorEdited);

            authorRepository.DeleteAuthor(author.AuthorId);
        }

        [TestMethod]
        public void CanDeleteAuthor()
        {
            var author = new Author
            {
                FName = "FName1",
                LName = "LName1"
            };

            authorRepository.SaveAuthor(author);

            author = authorRepository.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName1");
            Assert.IsNotNull(author);

            authorRepository.DeleteAuthor(author.AuthorId);

            author = authorRepository.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName1");
            Assert.IsNull(author);
        }
    }
}
