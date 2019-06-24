using System.Collections.Generic;
using System.Data.Entity;
using TechLib.Domain.Entities;
using TechLib.Domain.Repositories;

namespace TechLib.DataAccess.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly AppDbContext db;

        public ReaderRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Reader> Readers => db.Readers;

        public void SaveReader(Reader reader)
        {
            if (reader.ReaderId == 0) // create
            {
                db.Readers.Add(reader);
            }
            else // edit
            {
                db.Entry(reader).State = EntityState.Modified;
            }

            db.SaveChanges();
        }

        public void DeleteReader(int readerId)
        {
            var reader = db.Readers.Find(readerId);
            if (reader == null) return;

            db.Readers.Remove(reader);
            db.SaveChanges();
        }
    }
}
