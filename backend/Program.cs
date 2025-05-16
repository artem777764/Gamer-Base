using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;
using backend.Models;
using backend.Repositories;
using backend.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

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

builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRES_CONNECTION")!));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    return new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION")!);
});
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IOurAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddSingleton<ContentTypeService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

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