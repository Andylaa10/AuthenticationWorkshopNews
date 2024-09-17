using NewsService.Dtos;

namespace NewsService.Interfaces;

public interface IUserService
{
    public Task<IEnumerable<GetUserDto>> GetUsers();
    public Task<GetUserDto> GetUserById(string userId);
    public Task UpdateUser(string userId, UpdateUserDto user);
    public Task DeleteUser(string userId);
}