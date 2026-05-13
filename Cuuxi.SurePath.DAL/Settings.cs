using Cuuxi.SurePath.DAL.DbContexts;

namespace Cuuxi.SurePath.DAL
{
    public class Settings
    {
        internal SurePathDbContext DbContext { get; }

        public Settings(SurePathDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
