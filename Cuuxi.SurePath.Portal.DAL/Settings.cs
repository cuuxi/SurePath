namespace Cuuxi.SurePath.Portal.DAL
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
