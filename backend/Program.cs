using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;
using backend.Models;
using backend.Repositories;
using backend.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

//swagger: http://localhost:5007/swagger/index.html
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Gamer Base API",
        Version = "v1"
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = false;
    });

var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION");
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gamer Base API");
    });
}

app.UseRouting();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();