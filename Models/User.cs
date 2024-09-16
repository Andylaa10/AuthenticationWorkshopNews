namespace Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public List<Article>? Articles { get; set; }
    public List<Comment>? Comments { get; set; }
}