using Models;

namespace NewsRepository.Interfaces;

public interface ICommentRepository
{
    public Task<IEnumerable<Comment>> GetComments();
    public Task<Comment> GetCommentById(int commentId);
    public Task<Comment> AddComment(Comment comment);
    public Task UpdateComment(int commentId, Comment comment);
    public Task DeleteComment(int commentId);
}