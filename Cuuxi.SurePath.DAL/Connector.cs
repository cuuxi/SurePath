using Cuuxi.SurePath.DAL.Repositories;
using Cuuxi.Toolbox.Framework.Connector;

namespace Cuuxi.SurePath.DAL
{
    public class Connector : IConnector
    {
        internal readonly Settings settings;
        private readonly ConnectorHandler connectorHandler;

        public Connector(Settings settings)
        {
            this.settings = settings;
            this.connectorHandler = new ConnectorHandler(this);
        }

        public IConnector GetConnectorAsync()
        {
            return new Connector(this.settings);
        }

        public TestRepository Test => this.connectorHandler.GetRepository<TestRepository>();
        public SystemSettingsRepository SystemSettings => this.connectorHandler.GetRepository<SystemSettingsRepository>();
        public CountriesRepository Countries => this.connectorHandler.GetRepository<CountriesRepository>();
        public UsersRepository Users => this.connectorHandler.GetRepository<UsersRepository>();
        public UserLoginsRepository UserLogins => this.connectorHandler.GetRepository<UserLoginsRepository>();
        public UserLoginLogsRepository UserLoginLogs => this.connectorHandler.GetRepository<UserLoginLogsRepository>();
        public LanguagesRepository Languages => this.connectorHandler.GetRepository<LanguagesRepository>();
        public TranslationKeysRepository TranslationKeys => this.connectorHandler.GetRepository<TranslationKeysRepository>();
        public TranslationsRepository Translations => this.connectorHandler.GetRepository<TranslationsRepository>();

        public void Dispose()
        {
            this.connectorHandler.Dispose();
            this.settings.Dispose();
        }
    }
}
