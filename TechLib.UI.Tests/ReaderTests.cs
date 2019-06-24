using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLib.DataAccess;
using TechLib.DataAccess.Repositories;
using TechLib.UI.Reader;

namespace TechLib.UI.Tests
{
    [TestClass]
    public class ReaderTests
    {
        private readonly ReaderViewModel readerViewModel;

        public ReaderTests()
        {
            readerViewModel = new ReaderViewModel(new ReaderRepository(new AppDbContext()));
        }

        [TestMethod]
        public void CanGetReaderList()
        {
            var readers = readerViewModel.ReaderList;

            Assert.IsNotNull(readers);
            Assert.IsInstanceOfType(readers.FirstOrDefault(), typeof(Domain.Entities.Reader));
        }
    }
}
