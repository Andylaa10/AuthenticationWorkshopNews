using Models;

namespace NewsRepository.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUserById(int userId);
    public Task<User> AddUser(User user);
    public Task UpdateUser(int userId, User user);
    public Task DeleteUser(int userId);
    public Task RebuildDb();
}