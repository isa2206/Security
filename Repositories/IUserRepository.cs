using Security.Models;

namespace Security.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAddress(string emailAddress);
        Task AddAsync(User user);
    }
}
