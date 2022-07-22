using Contract.Blogs.Create;
using Domain.Entities;
using FastEndpoints;

namespace Api.Features.Blogs.Create;

public class Mapper : Mapper<Request, Response, Blog>
{
    public override Response FromEntity(Blog e) => new() { BlogId = e.Id };
    public override Blog ToEntity(Request r) => new() { Title = r.Title, Content = r.Content };
}