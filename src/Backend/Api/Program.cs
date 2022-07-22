using DataAccess;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
var app = builder.Build();

app.Services.ApplyMigrations();

app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());

app.Run();