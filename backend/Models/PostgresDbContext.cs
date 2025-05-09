using backend.Models.Configurations;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

class PostgresDbContext : DbContext
{
    public DbSet<CommentEntity> Comments { get; set; } = null!;
    public DbSet<DeveloperEntity> Developers { get; set; } = null!;
    public DbSet<EntityType> EntityTypes { get; set; } = null!;
    public DbSet<FavouriteGamesEntity> FavouriteGames { get; set; } = null!;
    public DbSet<GameEntity> Games { get; set; } = null!;
    public DbSet<GameGenresEntity> GameGenres { get; set; } = null!;
    public DbSet<GamePlatformsEntity> GamePlatforms { get; set; } = null!;
    public DbSet<GenreEntity> Genres { get; set; } = null!;
    public DbSet<NotificationEntity> Notifications { get; set; } = null!;
    public DbSet<PlatformEntity> Platforms { get; set; } = null!;
    public DbSet<PublisherEntity> Publishers { get; set; } = null!;
    public DbSet<ReviewEntity> Reviews { get; set; } = null!;
    public DbSet<UserDataEntity> UserData { get; set; } = null!;
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<VoteCommentEntity> VotesComment { get; set; } = null!;
    public DbSet<VoteReviewEntity> VotesReview { get; set; } = null!;

    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new DeveloperConfiguration());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FavouriteGamesConfiguration());
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new GameGenresConfiguration());
        modelBuilder.ApplyConfiguration(new GamePlatformsConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        modelBuilder.ApplyConfiguration(new PlatformConfiguration());
        modelBuilder.ApplyConfiguration(new PublisherConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserDataConfiguration());
        modelBuilder.ApplyConfiguration(new VoteCommentConfiguration());
        modelBuilder.ApplyConfiguration(new VoteReviewConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}