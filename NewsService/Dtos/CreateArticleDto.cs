namespace NewsService.Dtos;

public class CreateArticleDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorId { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}