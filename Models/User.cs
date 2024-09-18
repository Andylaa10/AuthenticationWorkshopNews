using Microsoft.AspNetCore.Identity;

namespace Models;

public class User : IdentityUser
{
    public virtual List<Article>? Articles { get; set; }
    public virtual List<Comment>? Comments { get; set; }
}