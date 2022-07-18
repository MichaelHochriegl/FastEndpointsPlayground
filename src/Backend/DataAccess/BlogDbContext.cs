using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class BlogDbContext : DbContext, IBlogDbContext
{
    public BlogDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Blog> Blogs => Set<Blog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}