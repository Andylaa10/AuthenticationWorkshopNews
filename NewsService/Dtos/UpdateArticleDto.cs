namespace NewsService.Dtos;

public class UpdateArticleDto
{
    public int ArticleId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}