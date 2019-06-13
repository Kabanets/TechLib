using System.Collections.Generic;
using TechLib.Domain.Entities;

namespace TechLib.Domain.Repositories
{
    public interface IReaderRepo
    {
        IEnumerable<Reader> Readers { get; }
        void SaveReader(Reader reader);
        void DeleteReader(int readerId);
    }
}
