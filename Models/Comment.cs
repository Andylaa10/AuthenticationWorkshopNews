namespace Models;

public class Comment
{
    public int CommentId { get; set; }
    public string Content { get; set; }
    public int ArticleId { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public User? User { get; set; }
    public Article? Article { get; set; }
}