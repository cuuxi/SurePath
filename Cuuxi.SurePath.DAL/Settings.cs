using Cuuxi.SurePath.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL
{
    public class Settings : IDisposable
    {
        private readonly string _connectionString;
        private SurePathDbContext? _dbContext;

        public Settings(string connectionString = "")
        {
            _connectionString = connectionString;
        }

        internal SurePathDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    var options = new DbContextOptionsBuilder<SurePathDbContext>()
                        .UseSqlServer(_connectionString)
                        .Options;
                    _dbContext = new SurePathDbContext(options);
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
