using Cuuxi.SurePath.Web.DAL.Repositories;
using Cuuxi.Toolbox.Framework.Connector;

namespace Cuuxi.SurePath.Web.DAL
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
        public TranslationsRepository Translations => this.connectorHandler.GetRepository<TranslationsRepository>();

        public void Dispose()
        {
            this.connectorHandler.Dispose();
            this.settings.Dispose();
        }
    }
}
