namespace NewsService.Dtos;

public class UpdateUserDto
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}