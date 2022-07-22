using Contract.Blogs.Create;
using DataAccess;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Blogs.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    private readonly IBlogDbContext _dbContext;

    public Endpoint(IBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/api/blogs");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Logger.LogInformation("creating blog with title '{blogTitle}'", req.Title);

        if (await _dbContext.Blogs.AnyAsync(x => x.Title == req.Title, cancellationToken: ct))
        {
            Logger.LogWarning("blog not creating, blog with the same title is already present");
            AddError(e => e.Title, 
                $"Blog with title '{req.Title}' already present");
        }
        
        ThrowIfAnyErrors();
        
        var blog = Map.ToEntity(req);
        blog = _dbContext.Blogs.Add(blog).Entity;
        await _dbContext.SaveChangesAsync(ct);
        
        Logger.LogInformation("blog saved with ID '{blogId}'", blog.Id);
        
        await SendAsync(Map.FromEntity(blog), cancellation: ct);
    }
}