namespace Contract.Blogs.Create;

public class Request
{
    public string Title { get; set; }
    public string Content { get; set; }
}

public class Response
{
    public Guid BlogId { get; set; }
}