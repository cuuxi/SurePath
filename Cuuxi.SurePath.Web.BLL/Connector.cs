using Cuuxi.SurePath.Web.BLL.Services;
using Cuuxi.Toolbox.Framework.Connector;

namespace Cuuxi.SurePath.Web.BLL
{
    public class Connector : IConnector
    {
        internal readonly Settings settings;
        private readonly ConnectorHandler connectorHandler;
        private DAL.Connector? _DAL;

        public Connector(Settings settings)
        {
            this.settings = settings;
            this.connectorHandler = new ConnectorHandler(this);
        }

        public IConnector GetConnectorAsync()
        {
            return new Connector(this.settings);
        }

        internal DAL.Connector DAL
        {
            get
            {
                _DAL ??= new DAL.Connector(new DAL.Settings(settings.ConnectionString));
                return _DAL;
            }
        }

        public TestService Test => this.connectorHandler.GetRepository<TestService>();
        public TranslationService Translations => this.connectorHandler.GetRepository<TranslationService>();

        public void Dispose()
        {
            this.connectorHandler.Dispose();

            if (this._DAL != null)
                this._DAL.Dispose();
        }
    }
}
