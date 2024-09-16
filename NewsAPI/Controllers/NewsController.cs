using Microsoft.AspNetCore.Mvc;
using NewsService.Dtos;
using NewsService.Interfaces;

namespace NewsAPI.Controllers;

[ApiController]
[Route("/[controller]")]
public class NewController(IUserService userService, IArticleService articleService, ICommentService commentService) : ControllerBase
{
    [HttpGet]
    [Route("/user")]
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
    [Route("/user/{userId}")]
    public async Task<IActionResult> GetUserById([FromRoute] int userId)
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

    [HttpPost]
    [Route("/user")]
    public async Task<IActionResult> AddUser([FromBody] CreateUserDto user)
    {
        try
        {
            return Created("",await userService.AddUser(user));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut]
    [Route("/user/{userId}")]
    public async Task<IActionResult> UpdateUser([FromRoute] int userId, [FromBody] UpdateUserDto user)
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
    [Route("/user/{userId}")]
    public async Task<IActionResult> DeleteUser([FromRoute]int userId)
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
    
    [HttpPost]
    [Route("/rebuild")]
    public async Task<IActionResult> RebuildDb()
    {
        try
        {
            await userService.RebuildDb();
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("/article")]
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

    [HttpPost]
    [Route("/article/{articleId}")]
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
    [Route("/article")]
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
    [Route("/article/{articleId}")]
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
    [Route("/article/{articleId}")]
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
    [Route("/comment")]
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
    [Route("/comment/{commentId}")]
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
    [Route("/comment")]
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
    [Route("/comment/{commentId}")]
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
    [Route("/comment/{commentId}")]
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