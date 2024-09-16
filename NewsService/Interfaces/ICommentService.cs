using Models;
using NewsService.Dtos;

namespace NewsService.Interfaces;

public interface ICommentService
{
    public Task<IEnumerable<Comment>> GetComments();
    public Task<Comment> GetCommentById(int commentId);
    public Task<Comment> AddComment(CreateCommentDto comment);
    public Task UpdateComment(int commentId, UpdateCommentDto comment);
    public Task DeleteComment(int commentId);
}