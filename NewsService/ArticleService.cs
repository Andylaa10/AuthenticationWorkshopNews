using AutoMapper;
using Models;
using NewsRepository.Interfaces;
using NewsService.Dtos;
using NewsService.Interfaces;

namespace NewsService;

public class ArticleService(IArticleRepository articleRepository, IMapper mapper) : IArticleService
{
    public async Task<IEnumerable<Article>> GetArticles()
    {
        return await articleRepository.GetArticles();
    }

    public async Task<Article> GetArticleById(int articleId)
    {
        if(articleId < 1)
            throw new ArgumentException("Article id must be greater than 0");
        
        return await articleRepository.GetArticleById(articleId); 
    }

    public async Task<Article> AddArticle(CreateArticleDto article)
    {
        return await articleRepository.AddArticle(mapper.Map<Article>(article));
    }

    public async Task UpdateArticle(int articleId, UpdateArticleDto article)
    {
        if (articleId < 1)
            throw new ArgumentException("Article id must be greater than 0");
        await articleRepository.UpdateArticle(articleId,mapper.Map<Article>(article));
    }

    public async Task DeleteArticle(int articleId)
    {
        if (articleId < 1)
            throw new ArgumentException("Article id must be greater than 0");
        await articleRepository.DeleteArticle(articleId);
    }
    public async Task RebuildDb()
    {
        await articleRepository.RebuildDb();
    }
}