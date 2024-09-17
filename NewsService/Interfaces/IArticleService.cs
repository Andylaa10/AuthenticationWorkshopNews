using Models;
using NewsService.Dtos;

namespace NewsService.Interfaces;

public interface IArticleService
{
    public Task<IEnumerable<Article>> GetArticles();
    public Task<Article> GetArticleById(int articleId);
    public Task<Article> AddArticle(CreateArticleDto article);
    public Task UpdateArticle(int articleId, UpdateArticleDto article);
    public Task DeleteArticle(int articleId);
    public Task RebuildDb();

}