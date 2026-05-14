using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.Web.DAL
{
    public class Settings : IDisposable
    {
        private readonly string _connectionString;
        private WebDbContext? _dbContext;

        public Settings(string connectionString = "")
        {
            _connectionString = connectionString;
        }

        internal WebDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    var options = new DbContextOptionsBuilder<WebDbContext>()
                        .UseSqlServer(_connectionString)
                        .Options;
                    _dbContext = new WebDbContext(options);
                }
                return _dbContext;
            }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            _dbContext = null;
        }
    }
}
