namespace Cuuxi.SurePath.API.BLL
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
