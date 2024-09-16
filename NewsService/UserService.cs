using AutoMapper;
using Models;
using NewsRepository.Interfaces;
using NewsService.Dtos;
using NewsService.Interfaces;

namespace NewsService;

public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<IEnumerable<GetUserDto>> GetUsers()
    {
        return mapper.Map<IEnumerable<GetUserDto>>(await userRepository.GetUsers());
    }

    public async Task<GetUserDto> GetUserById(int userId)
    {
        if (userId < 1)
            throw new ArgumentException("User id must be greater than 0");
        return mapper.Map<GetUserDto>(await userRepository.GetUserById(userId));
    }

    public async Task<GetUserDto> AddUser(CreateUserDto user)
    {
        return mapper.Map<GetUserDto>(await userRepository.AddUser(mapper.Map<User>(user)));
    }

    public async Task UpdateUser(int userId, UpdateUserDto user)
    {
        if (userId < 1)
            throw new ArgumentException("User id must be greater than 0");
        await userRepository.UpdateUser(userId, mapper.Map<User>(user));
    }

    public async Task DeleteUser(int userId)
    {
        if (userId < 1)
            throw new ArgumentException("User id must be greater than 0");
        await userRepository.DeleteUser(userId);
    }

    public async Task RebuildDb()
    {
        await userRepository.RebuildDb();
    }
}