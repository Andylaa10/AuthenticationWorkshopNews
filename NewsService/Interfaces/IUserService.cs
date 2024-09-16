using NewsService.Dtos;

namespace NewsService.Interfaces;

public interface IUserService
{
    public Task<IEnumerable<GetUserDto>> GetUsers();
    public Task<GetUserDto> GetUserById(int userId);
    public Task<GetUserDto> AddUser(CreateUserDto user);
    public Task UpdateUser(int userId, UpdateUserDto user);
    public Task DeleteUser(int userId);
    public Task RebuildDb();
}