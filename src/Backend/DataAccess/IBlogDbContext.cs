using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public interface IBlogDbContext
{
    public DbSet<Blog> Blogs { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}