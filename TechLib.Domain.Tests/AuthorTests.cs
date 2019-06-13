using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechLib.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace TechLib.Domain.Tests
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void CanNotCreateAuthorFName101()
        {
            var author = new Author
            {
                AuthorId = 1,
                FName = "111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111",
                LName = "test"
            };

            var rusult = Validator.TryValidateObject(author, new ValidationContext(author), null, true);

            Assert.IsFalse(rusult);
        }
    }
}
