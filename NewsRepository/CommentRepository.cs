using Microsoft.EntityFrameworkCore;
using Models;
using NewsRepository.Helpers;
using NewsRepository.Interfaces;

namespace NewsRepository;

public class CommentRepository : ICommentRepository
{
    private readonly DatabaseContext _context;
    public CommentRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Comment>> GetComments()
    {
        return await _context.Comments.ToListAsync();
    }
    
    public async Task<Comment> GetCommentById(int commentId)
    {
        return await _context.Comments.FindAsync(commentId);
    }

    public async Task<Comment> AddComment(Comment comment)
    {
        var newComment = await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return newComment.Entity;
    }

    public async Task UpdateComment(int commentId, Comment comment)
    {
        var commentToUpdate = await _context.Comments.FindAsync(commentId);
        
        if(commentToUpdate == null)
            throw new KeyNotFoundException("Comment not found");
        
        commentToUpdate.Content = comment.Content;
        _context.Comments.Update(commentToUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteComment(int commentId)
    {
        var commentToDelete = await _context.Comments.FindAsync(commentId);
        
        if(commentToDelete == null)
            throw new KeyNotFoundException("Comment not found");
        
        _context.Comments.Remove(commentToDelete);
        await _context.SaveChangesAsync();
    }
}