using Cuuxi.SurePath.Backend.BLL.Services;
using Cuuxi.Toolbox.Framework.Connector;

namespace Cuuxi.SurePath.Backend.BLL
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


        private DAL.Connector? _DAL;
        internal DAL.Connector DAL
        {
            get
            {
                if (this._DAL == null)
                    this._DAL = new DAL.Connector(new Backend.DAL.Settings());

                return this._DAL;
            }
        }


        public TestService Test => this.connectorHandler.GetRepository<TestService>();


        public void Dispose()
        {
            this.connectorHandler.Dispose();

            if (this._DAL != null)
                this._DAL.Dispose();
        }
    }
}
