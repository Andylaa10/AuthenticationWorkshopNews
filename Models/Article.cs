namespace Models;

public class Article
{
    public int ArticleId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public User? User { get; set; }
    public List<Comment>? Comments { get; set; }
}