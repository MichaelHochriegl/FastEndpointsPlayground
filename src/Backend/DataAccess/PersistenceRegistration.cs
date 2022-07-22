using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class PersistenceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var useInMemory = configuration.GetValue<bool>("UseInMemoryDatabase");
        if (useInMemory)
        {
            services.AddDbContext<BlogDbContext>(options => 
                options.UseInMemoryDatabase("Blogster"));
        }
        else
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<BlogDbContext>(options => 
                options.UseNpgsql(connectionString));
        }

        services.AddScoped<IBlogDbContext, BlogDbContext>();
        
        return services;
    }

    public static IServiceProvider ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
        db.Database.Migrate();

        return serviceProvider;
    }
}