using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLib.Domain.Repositories;

namespace TechLib.UI.Reader
{
    public class ReaderViewModel
    {
        private readonly IReaderRepository readerRepository;

        public ReaderViewModel(IReaderRepository readerRepository)
        {
            this.readerRepository = readerRepository;
        }

        public List<Domain.Entities.Reader> ReaderList
        {
            get
            {
                var readers = readerRepository.Readers.AsQueryable()
                    .OrderBy(a => a.LName).ThenBy(a => a.FName)
                    .ToList();
                return readers;
            }
        }
    }
}
