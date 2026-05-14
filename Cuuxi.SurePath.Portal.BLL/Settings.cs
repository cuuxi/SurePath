namespace Cuuxi.SurePath.Portal.BLL
{
    public class Settings
    {
        internal string ConnectionString { get; }
        internal string ApiUrl { get; }

        public Settings(string connectionString = "", string apiUrl = null)
        {
            ConnectionString = connectionString;
            ApiUrl = apiUrl;
        }
    }
}
