using layerOne.interfaces;
using layerOne.models;
using System.Data.Entity;

namespace layerOne.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext db;

        public UserRepository(MyDbContext dbContext)
        {
            db = dbContext;
        }
        public async Task<bool> AddAsync(User entity)
        {
            try
            {
                await db.Users.AddAsync(entity);
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
            var entity = await db.Users.FindAsync(id);
            db.Users.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await db.Users.Include(x => x.Rents).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task UpdateAsync(User entity)
        {
            db.Users.Update(entity);
            await db.SaveChangesAsync();
        }
    }
}
