using Cuuxi.SurePath.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL.DbContexts;

public class SurePathDbContext : DbContext
{
    public SurePathDbContext(DbContextOptions<SurePathDbContext> options) : base(options)
    {
    }

    public DbSet<SystemSetting> SystemSettings => Set<SystemSetting>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserLogin> UserLogins => Set<UserLogin>();
    public DbSet<UserLoginLog> UserLoginLogs => Set<UserLoginLog>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<TranslationKey> TranslationKeys => Set<TranslationKey>();
    public DbSet<Translation> Translations => Set<Translation>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("surepath");

        builder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Code);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LanguageCode).IsRequired().HasMaxLength(10);
        });

        builder.Entity<User>(entity =>
        {
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CountryCode).IsRequired().HasMaxLength(10);
            entity.HasOne(e => e.Country)
                  .WithMany()
                  .HasForeignKey(e => e.CountryCode);
        });

        builder.Entity<UserLogin>(entity =>
        {
            entity.Property(e => e.Provider).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ProviderKey).IsRequired().HasMaxLength(500);
            entity.HasIndex(e => new { e.Provider, e.ProviderKey }).IsUnique();
            entity.HasOne(e => e.User)
                  .WithMany()
                  .HasForeignKey(e => e.UserId);
        });

        builder.Entity<UserLoginLog>(entity =>
        {
            entity.Property(e => e.Provider).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ProviderKey).IsRequired().HasMaxLength(500);
            entity.HasOne(e => e.User)
                  .WithMany()
                  .HasForeignKey(e => e.UserId)
                  .IsRequired(false);
        });

        builder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Code);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        builder.Entity<TranslationKey>(entity =>
        {
            entity.HasKey(e => e.Key);
            entity.Property(e => e.Key).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        builder.Entity<Translation>(entity =>
        {
            entity.Property(e => e.LanguageCode).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Key).IsRequired().HasMaxLength(200);
            entity.HasIndex(e => new { e.LanguageCode, e.Key }).IsUnique();
            entity.HasOne(e => e.Language)
                  .WithMany()
                  .HasForeignKey(e => e.LanguageCode)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.TranslationKey)
                  .WithMany()
                  .HasForeignKey(e => e.Key)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
