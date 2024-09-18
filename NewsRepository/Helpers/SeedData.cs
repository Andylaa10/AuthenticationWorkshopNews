using Microsoft.AspNetCore.Identity;
using Models;
using Models.Helpers;

namespace NewsRepository.Helpers;

public class SeedData(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, DatabaseContext dbContext)
{
    public async Task PopulateData()
    {
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();

        #region Create Roles

        await CreateRole(Roles.Admin);
        await CreateRole(Roles.Editor);
        await CreateRole(Roles.Subscriber);
        await CreateRole(Roles.Writer);

        #endregion
        
        #region Create Users
        var guest = await CreateUser("guest", "String@1234");
        var admin = await CreateUser("admin", "String@1234");
        var editor = await CreateUser("editor", "String@1234");
        var subscriber = await CreateUser("subscriber", "String@1234");
        var writer = await CreateUser("writer", "String@1234");
        
        #endregion

        #region Assign Roles
        await AddUserToRole(admin, Roles.Admin);
        await AddUserToRole(editor, Roles.Editor);
        await AddUserToRole(writer, Roles.Writer);
        await AddUserToRole(subscriber, Roles.Subscriber);
        #endregion
        
        #region Article
        var article1 = dbContext
            .Articles.Add(
                new Article
                {
                    Title = "First article",
                    Content = "Breaking news",
                    AuthorId = writer.Id,
                    User = writer
                }
            )
            .Entity;
        var article2 = dbContext
            .Articles.Add(
                new Article
                {
                    Title = "Second article",
                    Content = "Another breaking news",
                    AuthorId = writer.Id,
                    User = writer
                }
            )
            .Entity;
        dbContext.Comments.Add(
            new Comment
            {
                Content = "First comment",
                User = subscriber,
                UserId = subscriber.Id,
                Article = article1,
                ArticleId = article1.ArticleId
            }
        );
        dbContext.Comments.Add(
            new Comment
            {
                Content = "I'm a troll",
                User = subscriber,
                UserId = subscriber.Id,
                Article = article2,
                ArticleId = article2.ArticleId
            }
        );

        await dbContext.SaveChangesAsync();
        #endregion
    }

    private async Task<User> CreateUser(string username, string password)
    {
        var user = new User
        {
            Email = username,
            UserName = username,
            EmailConfirmed = true,
            LockoutEnabled = false
        };
        var result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            throw new Exception(string.Join(',', result.Errors));
        
        var newUser = await userManager.FindByNameAsync(username);
        Console.WriteLine(newUser.UserName);
        return newUser;
    }
    
    private async Task CreateRole(string roleName)
    {
        var role = new IdentityRole(roleName);
        await roleManager.CreateAsync(role);
    }

    private async Task AddUserToRole(User user, string roleName)
    {
        await userManager.AddToRoleAsync(user, roleName);
    }
}