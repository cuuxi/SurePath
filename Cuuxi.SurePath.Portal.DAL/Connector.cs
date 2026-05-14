using Cuuxi.SurePath.Portal.DAL.Repositories;
using Cuuxi.Toolbox.Framework.Connector;
using CentralDAL = Cuuxi.SurePath.DAL;

namespace Cuuxi.SurePath.Portal.DAL
{
    public class Connector : IConnector
    {
        internal readonly Settings settings;
        private readonly ConnectorHandler connectorHandler;
        private CentralDAL.Settings? _dalSettings;
        private CentralDAL.Connector? _dal;

        public Connector(Settings settings)
        {
            this.settings = settings;
            this.connectorHandler = new ConnectorHandler(this);
        }

        public IConnector GetConnectorAsync()
        {
            return new Connector(this.settings);
        }

        internal CentralDAL.Connector Dal
        {
            get
            {
                if (_dal == null)
                {
                    _dalSettings = new CentralDAL.Settings(settings.ConnectionString);
                    _dal = new CentralDAL.Connector(_dalSettings);
                }
                return _dal;
            }
        }

        public TestRepository Test => this.connectorHandler.GetRepository<TestRepository>();
        public UsersRepository Users => this.connectorHandler.GetRepository<UsersRepository>();
        public UserLoginsRepository UserLogins => this.connectorHandler.GetRepository<UserLoginsRepository>();
        public UserLoginLogsRepository UserLoginLogs => this.connectorHandler.GetRepository<UserLoginLogsRepository>();
        public CountriesRepository Countries => this.connectorHandler.GetRepository<CountriesRepository>();
        public TranslationsRepository Translations => this.connectorHandler.GetRepository<TranslationsRepository>();

        public void Dispose()
        {
            this.connectorHandler.Dispose();
            _dal?.Dispose();
            _dalSettings?.Dispose();
        }
    }
}
