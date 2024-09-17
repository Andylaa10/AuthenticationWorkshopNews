using Microsoft.AspNetCore.Identity;

namespace Models;

public class User : IdentityUser
{
    public List<Article>? Articles { get; set; }
    public List<Comment>? Comments { get; set; }
}