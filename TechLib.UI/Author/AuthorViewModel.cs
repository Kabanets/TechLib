using System.Collections.Generic;
using System.Linq;
using TechLib.Domain.Repositories;

namespace TechLib.UI.Author
{
    public class AuthorViewModel
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorViewModel(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public List<Domain.Entities.Author> AuthorList
        {
            get
            {
                var authors = authorRepository.Authors.AsQueryable()
                    .OrderBy(a => a.LName).ThenBy(a => a.FName)
                    .ToList();
                return authors;
            }
        }
    }
}
