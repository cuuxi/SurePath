using Cuuxi.SurePath.Web.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.Web.DAL;

public class WebDbContext : DbContext
{
    public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
    {
    }

    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Translation> Translations => Set<Translation>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("surepath");

        builder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Code);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        builder.Entity<Translation>(entity =>
        {
            entity.Property(e => e.LanguageCode).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Key).IsRequired().HasMaxLength(200);
            entity.HasIndex(e => new { e.LanguageCode, e.Key }).IsUnique();
        });
    }
}
