using Models;

namespace NewsRepository.Interfaces;

public interface IArticleRepository
{
    public Task<IEnumerable<Article>> GetArticles();
    public Task<Article> GetArticleById(int articleId);
    public Task<Article> AddArticle(Article article);
    public Task UpdateArticle(int articleId, Article article);
    public Task DeleteArticle(int articleId);
    public Task RebuildDb();

}