namespace Cuuxi.SurePath.Backend.DAL
{
    public class Settings
    {
        internal string ConnectionString { get; }

        public Settings(string connectionString = "")
        {
            ConnectionString = connectionString;
        }
    }
}
