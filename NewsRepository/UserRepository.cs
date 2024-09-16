using Microsoft.EntityFrameworkCore;
using Models;
using NewsRepository.Helpers;
using NewsRepository.Interfaces;

namespace NewsRepository;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;
    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<User> AddUser(User user)
    {
        var newUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task UpdateUser(int userId, User user)
    {
        var userToUpdate = await _context.Users.FindAsync(userId);
    
        if(userToUpdate == null)
            throw new KeyNotFoundException("User not found");
    
        userToUpdate.Username = user.Username;
        userToUpdate.PasswordHash = user.PasswordHash;
        _context.Users.Update(userToUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int userId)
    {
        var userToDelete = await _context.Users.FindAsync(userId);
    
        if(userToDelete == null)
            throw new KeyNotFoundException("User not found");
    
        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task RebuildDb()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.Database.EnsureCreatedAsync();
    }
    
}