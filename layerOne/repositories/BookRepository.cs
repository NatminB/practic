using layerOne.interfaces;
using layerOne.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace layerOne.repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly MyDbContext db;

        public BookRepository(MyDbContext dbContext)
        {
            db = dbContext;
        }
        public async Task<bool> AddAsync(Book entity)
        {
            try
            {
                await db.Books.AddAsync(entity);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await db.Books.FindAsync(id);
            db.Books.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await db.Books.Include(x => x.Rents).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await db.Books.FirstOrDefaultAsync(x => x.BookId == id);
        }

        public async Task TakeOff(Book book)
        {
            await UpdateAsync(book);
        }

        public async Task UpdateAsync(Book entity)
        {
            db.Books.Update(entity);
            await db.SaveChangesAsync();
        }
    }
}
