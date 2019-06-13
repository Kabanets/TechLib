using System.Collections.Generic;
using TechLib.Domain.Entities;

namespace TechLib.Domain.Repositories
{
    public interface IAuthorRepo
    {
        IEnumerable<Author> Authors { get; }
        void SaveAuthor(Author author);
        void DeleteAuthor(int authorId);
    }
}
