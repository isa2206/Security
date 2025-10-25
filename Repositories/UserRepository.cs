using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Models;

namespace Security.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async  Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async  Task<User> GetByEmailAddress(string emailAddress)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == emailAddress);
        }
    }
}
