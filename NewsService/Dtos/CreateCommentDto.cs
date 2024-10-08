﻿namespace NewsService.Dtos;

public class CreateCommentDto
{
    public string Content { get; set; }
    public int ArticleId { get; set; }
    public string UserId { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}