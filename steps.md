## Rough steps to forget nothing

1. Create empty Solution
2. Create folder structure
3. Create `Contract` project, this will hold the actual API contracts for e.g. a Blog post
4. Install `FluentValidation` for the `Contract` project
5. Create the folder for the first feature, e.g. `Blogs/Create`
6. Create `Constants` class inside the `Blogs` folder, this will hold validation limits for our feature
7. Create `Models` class inside the feature folder, this class will hold the request and response models
8. Create `Validator` class inside the feature folder, this class will hold the validator for the request
9. Create `IContractMarker` interface inside the `Contract` project, this will be used to get the assembly scanning
10. Inside the `Backend` folder create a new ASP.Net core web app project called `Api` (choose with Docker support)
11. Install the nuget packages `FastEndpoints`, `FastEndpoints.Swagger`, `FastEndpoints.Security`, `Microsoft.EntityFrameworkCore.Design` inside the `Api` project
12. Create a `Features/Blogs/Create` folder structure inside the `Api` project, this will hold the actual endpoint and the mapper
13. Add a reference to the `Contract` project
14. Inside the `Backend` folder create a new class lib project called `Domain`
15. Add a folder called `Entities` and create a class called `Blog` with the appropriate properties
16. Inside the `Backend` folder create a new class lib project called `DataAccess`
17. Install `Npgsql.EntityFrameworkCore.PostgreSQL` inside the `DataAccess` project
18. Add reference to `Domain` and `Contract` to `DataAccess`
19. Create interface `IBlogDbContext` and add `DbSet<Blog>` and `SaveChangesAsync`
20. Create class `BlogDbContext` and inherit from `DbContext` and implement `IBlogDbContext`
21. Override `OnModelCreating` and apply configurations with Assembly-scanning
22. Create a `Configuration` folder inside the `DataAccess` project, this will hold our DB configuration that EF Core will use
23. Create a class `BlogConfiguration` inside the `Configuration` folder and implement the interface `IEntityTypeConfiguration<Blog>`
24. Create a static class `PersistenceRegistration` with a static extension method `AddPersistence`
25. Add ref for `DataAccess` project to `Api` project
26. Register persistence services with the extension method `AddPersistence`
27. Pull Docker image for `Postgres`: `docker pull postgres`
28. Run `Postgres` container: `docker run --name blogster-postgres -e POSTGRES_PASSWORD=mysecretpassword -e POSTGRES_USER=blogster -p 5432:5432 -d postgres`
29. Add ConnectionString to `appsettings.Development.json`: `"DbConnection": "\nServer=127.0.0.1;Port=5432;Database=blogster;User Id=blogster;Password=mysecretpassword;\n"`
30. Create initial Migration (call this command from the `src/Backend` folder): `dotnet ef migrations add InitialCreate --output-dir Migrations/PostgreSQL --startup-project ./Api/Api.csproj --project ./DataAccess/DataAccess.csproj`
31. Create a new extension method in `PersistenceRegistration` to apply the migrations programmatically on app start (note: this should not be done in production!)
32. Implement the endpoint and the mapper
33. 
