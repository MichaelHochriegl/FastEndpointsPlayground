namespace Domain.Entities;

public class Blog
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTimeOffset CreationDateTime { get; set; }
    public DateTimeOffset UpdateDateTime { get; set; }
}