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
        private readonly IAuthorRepo authorRepo;
        public AuthorRepoTests()
        {
            authorRepo = new AuthorRepo(new AppDbContext());
        }

        [TestMethod]
        public void CanCreateAuthor()
        {
            var author = new Author
            {
                FName = "FName1",
                LName = "LName1"
            };

            authorRepo.SaveAuthor(author);

            var autorCreated = authorRepo.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName1" && a.LName == "LName1");
            Assert.IsNotNull(autorCreated);

            authorRepo.DeleteAuthor(author.AuthorId);
        }

        [TestMethod]
        public void CanEditAuthor()
        {
            var author = new Author
            {
                FName = "FName1",
                LName = "LName1"
            };

            authorRepo.SaveAuthor(author);

            author = authorRepo.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName1");
            Assert.IsNotNull(author);

            author.FName = "FName2";
            author.LName = "LName2";

            authorRepo.SaveAuthor(author);

            var authorEdited = authorRepo.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName2" && a.LName == "LName2");
            Assert.IsNotNull(authorEdited);

            authorRepo.DeleteAuthor(author.AuthorId);
        }

        [TestMethod]
        public void CanDeleteAuthor()
        {
            var author = new Author
            {
                FName = "FName1",
                LName = "LName1"
            };

            authorRepo.SaveAuthor(author);

            author = authorRepo.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName1");
            Assert.IsNotNull(author);

            authorRepo.DeleteAuthor(author.AuthorId);

            author = authorRepo.Authors.AsQueryable().FirstOrDefault(a => a.FName == "FName1");
            Assert.IsNull(author);
        }
    }
}
