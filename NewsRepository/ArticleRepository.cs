using Microsoft.EntityFrameworkCore;
using Models;
using NewsRepository.Helpers;
using NewsRepository.Interfaces;

namespace NewsRepository;

public class ArticleRepository : IArticleRepository
{
    private readonly DatabaseContext _context;
    public ArticleRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Article>> GetArticles()
    {
        return await _context.Articles.ToListAsync();
    }
    
    public async Task<Article> GetArticleById(int articleId)
    {
        return await _context.Articles.FindAsync(articleId);
    }

    public async Task<Article> AddArticle(Article article)
    {
        var newArticle = await _context.Articles.AddAsync(article);
        await _context.SaveChangesAsync();
        return newArticle.Entity;
    }

    public async Task UpdateArticle(int articleId, Article article)
    {
        var articleToUpdate = await _context.Articles.FindAsync(articleId);
        
        if(articleToUpdate == null)
            throw new KeyNotFoundException("Article not found");
        
        articleToUpdate.Title = article.Title;
        articleToUpdate.Content = article.Content;
        _context.Articles.Update(articleToUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteArticle(int articleId)
    {
        var articleToDelete = await _context.Articles.FindAsync(articleId);
        
        if(articleToDelete == null)
            throw new KeyNotFoundException("Article not found");
        
        _context.Articles.Remove(articleToDelete);
        await _context.SaveChangesAsync();
    }
}