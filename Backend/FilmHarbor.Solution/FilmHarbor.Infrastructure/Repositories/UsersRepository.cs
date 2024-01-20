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
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == userName);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            _dbContext.RemoveRange(_dbContext.Users.Where(user => user.Id == userId));
            int rowsDeleted = await _dbContext.SaveChangesAsync();

            return rowsDeleted > 0;
        }

        public Task<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
