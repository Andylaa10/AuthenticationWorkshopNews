using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using NewsRepository.Helpers;
using NewsRepository.Interfaces;

namespace NewsRepository;

public class UserRepository(UserManager<User> userManager) : IUserRepository
{
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await userManager.Users.ToListAsync();
    }

    public async Task<User> GetUserById(string userId)
    {
        return await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task UpdateUser(string userId, User user)
    {
        var userToUpdate = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if(userToUpdate == null)
            throw new KeyNotFoundException("User not found");
    
        userToUpdate.UserName = user.UserName;
        userToUpdate.PasswordHash = user.PasswordHash;
        await userManager.UpdateAsync(userToUpdate);
    }

    public async Task DeleteUser(string userId)
    {
        var userToDelete = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
    
        if(userToDelete == null)
            throw new KeyNotFoundException("User not found");
    
        await userManager.DeleteAsync(userToDelete);
    }
}