using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using FilmHarbor.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FilmHarbor.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FilmHarborDbContext _dbContext;

        public UsersRepository(FilmHarborDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByUserId(int userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<User?> GetUserByUserName(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Name == userName);
        }

        public async Task<User> AddUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            _dbContext.RemoveRange(_dbContext.Users.Where(user => user.Id == userId));
            int rowsDeleted = await _dbContext.SaveChangesAsync();

            return rowsDeleted > 0;
        }

        public async Task<User> UpdateUser(User user)
        {
            User? matchingUser = await _dbContext.Users.FirstOrDefaultAsync(m => m.Id == user.Id);

            if (matchingUser == null)
            {
                return user;
            }

            matchingUser.Name = user.Name;
            matchingUser.Password = user.Password;
            matchingUser.Email = user.Email;

            int rowsUpdated = await _dbContext.SaveChangesAsync();

            return matchingUser;
        }
    }
}
