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
    internal class RentRepository : IRentRepository
    {
        private readonly MyDbContext db;

        public RentRepository(MyDbContext dbContext)
        {
            db = dbContext;
        }
        public async Task<bool> AddAsync(Rent entity)
        {
            try
            {
                await db.Rents.AddAsync(entity);
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
            var entity = await db.Rents.FindAsync(id);
            db.Rents.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rent>> GetAllAsync()
        {
            return await db.Rents.Include(x => x.Book).Include(x => x.User).ToListAsync();
        }

        public async Task<Rent> GetByIdAsync(int id)
        {
            return await db.Rents.FirstOrDefaultAsync(x => x.RentId == id);
        }

        public async Task UpdateAsync(Rent entity)
        {
            db.Rents.Update(entity);
            await db.SaveChangesAsync();
        }
    }
}
