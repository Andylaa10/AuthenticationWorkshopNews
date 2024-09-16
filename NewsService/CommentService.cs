using AutoMapper;
using Models;
using NewsRepository.Interfaces;
using NewsService.Dtos;
using NewsService.Interfaces;

namespace NewsService;

public class CommentService(ICommentRepository commentRepository, IMapper mapper) : ICommentService
{
    public async Task<IEnumerable<Comment>> GetComments()
    {
        return await commentRepository.GetComments();
    }

    public async Task<Comment> GetCommentById(int commentId)
    {
        if (commentId < 1)
            throw new ArgumentException("Comment Id cannot be less than 1");
        return await commentRepository.GetCommentById(commentId);
    }

    public async Task<Comment> AddComment(CreateCommentDto comment)
    {
        return await commentRepository.AddComment(mapper.Map<Comment>(comment));
    }

    public async Task UpdateComment(int commentId, UpdateCommentDto comment)
    {
        if (commentId < 1)
            throw new ArgumentException("Comment Id cannot be less than 1");
        await commentRepository.UpdateComment(commentId, mapper.Map<Comment>(comment));
    }

    public async Task DeleteComment(int commentId)
    {
        if (commentId < 1)
            throw new ArgumentException("Comment Id cannot be less than 1");
        await commentRepository.DeleteComment(commentId);
    }
}