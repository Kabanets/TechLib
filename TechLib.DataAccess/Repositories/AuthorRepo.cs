using System.Collections.Generic;
using System.Data.Entity;
using TechLib.Domain.Entities;
using TechLib.Domain.Repositories;

namespace TechLib.DataAccess.Repositories
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext db;

        public AuthorRepo(AppDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Author> Authors => db.Authors;

        public void SaveAuthor(Author author)
        {
            if(author.AuthorId == 0)
            {
                db.Authors.Add(author);
            }
            else
            {
                db.Entry(author).State = EntityState.Modified;
            }

            db.SaveChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            var author = db.Authors.Find(authorId);
            if (author == null) return;

            db.Authors.Remove(author);
            db.SaveChanges();
        }


    }
}
