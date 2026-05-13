using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.Web.DAL;

public class WebDbContext : DbContext
{
    public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("web");
    }
}
