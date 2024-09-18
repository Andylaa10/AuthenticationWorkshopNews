using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsService.Dtos;
using NewsService.Interfaces;

namespace NewsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsController(IUserService userService, IArticleService articleService, ICommentService commentService) : ControllerBase
{
    [HttpGet]
    [Route("user")]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            return Ok(await userService.GetUsers());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("user/{userId}")]
    public async Task<IActionResult> GetUserById([FromRoute] string userId)
    {
        try
        {
            return Ok(await userService.GetUserById(userId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut]
    [Route("user/{userId}")]
    public async Task<IActionResult> UpdateUser([FromRoute] string userId, [FromBody] UpdateUserDto user)
    {
        try
        {
            await userService.UpdateUser(userId, user);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpDelete]
    [Route("user/{userId}")]
    public async Task<IActionResult> DeleteUser([FromRoute]string userId)
    {
        try
        {
            await userService.DeleteUser(userId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("user/roles")]
    public async Task<IActionResult> GetRoles()
    {
        try
        {
            return Ok(await userService.GetRoles());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("user/role/{userId}")]
    public async Task<IActionResult> GetUserRoles([FromRoute] string userId)
    {
        try
        {
            return Ok(await userService.GetUserRoles(userId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Route("rebuild")]
    public async Task<IActionResult> RebuildDb()
    {
        try
        {
            await articleService.RebuildDb();
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("article")]
    public async Task<IActionResult> GetArticles()
    {
        try
        {
            return Ok(await articleService.GetArticles());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("article/{articleId}")]
    public async Task<IActionResult> GetArticleById([FromRoute]int articleId)
    {
        try
        {
            return Ok(await articleService.GetArticleById(articleId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPost]
    [Authorize(Roles = "Writer,Admin")]
    [Route("article")]
    public async Task<IActionResult> AddArticle([FromBody]CreateArticleDto article)
    {
        try
        {
            return Created("",await articleService.AddArticle(article));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut]
    [Authorize(Roles = "Writer,Admin,Editor")]
    [Route("article/{articleId}")]
    public async Task<IActionResult> UpdateArticle([FromRoute]int articleId, [FromBody]UpdateArticleDto article)
    {
        try
        {
            await articleService.UpdateArticle(articleId, article);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete]
    [Authorize(Roles = "Editor,Admin")]
    [Route("article/{articleId}")]
    public async Task<IActionResult> DeleteArticle([FromRoute]int articleId)
    {
        try
        {
            await articleService.DeleteArticle(articleId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("comment")]
    public async Task<IActionResult> GetComments()
    {
        try
        {
            return Ok(await commentService.GetComments());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("comment/{commentId}")]
    public async Task<IActionResult> GetCommentById([FromRoute] int commentId)
    {
        try
        {
            return Ok(await commentService.GetCommentById(commentId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    [Authorize(Roles = "Subscriber,Admin")]
    [Route("comment")]
    public async Task<IActionResult> AddComment([FromBody] CreateCommentDto comment)
    {
        try
        {
            return Created("",await commentService.AddComment(comment));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut]
    [Route("comment/{commentId}")]
    public async Task<IActionResult> UpdateComment([FromRoute] int commentId, [FromBody] UpdateCommentDto comment)
    {
        try
        {
            await commentService.UpdateComment(commentId, comment);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete]
    [Authorize(Roles = "Editor,Admin")]
    [Route("comment/{commentId}")]
    public async Task<IActionResult> DeleteComment([FromRoute] int commentId)
    {
        try
        {
            await commentService.DeleteComment(commentId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}