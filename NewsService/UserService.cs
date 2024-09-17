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

    public async Task<GetUserDto> GetUserById(string userId)
    {
        if (userId == null)
            throw new ArgumentException("User id cannot be null");
        return mapper.Map<GetUserDto>(await userRepository.GetUserById(userId));
    }

    public async Task UpdateUser(string userId, UpdateUserDto user)
    {
        if (userId == null)
            throw new ArgumentException("User id cannot be null");
        await userRepository.UpdateUser(userId, mapper.Map<User>(user));
    }

    public async Task DeleteUser(string userId)
    {
        if (userId == null)
            throw new ArgumentException("User id cannot be null");
        await userRepository.DeleteUser(userId);
    }
}