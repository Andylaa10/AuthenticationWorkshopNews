using Microsoft.AspNetCore.Identity;
using Models;

namespace NewsRepository.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUserById(string userId);
    public Task UpdateUser(string userId, User user);
    public Task DeleteUser(string userId);
    public Task<IEnumerable<IdentityRole>> GetRoles();
    public Task<IEnumerable<string>> GetUserRoles(string userId);
}