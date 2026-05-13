using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cuuxi.SurePath.DAL.DbContexts;

public class SurePathDbContextFactory : IDesignTimeDbContextFactory<SurePathDbContext>
{
    public SurePathDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SurePathDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SurePath;Trusted_Connection=True;");

        return new SurePathDbContext(optionsBuilder.Options);
    }
}
