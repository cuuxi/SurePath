using Cuuxi.SurePath.Portal.BLL.Services;
using Cuuxi.Toolbox.Framework.Connector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuuxi.SurePath.Portal.BLL
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
                    this._DAL = new DAL.Connector(new Portal.DAL.Settings());

                return this._DAL;
            }
        }



        public TestService Test => this.connectorHandler.GetRepository<TestService>();


        public void Dispose()
        {
            // Add all cleanup here

            this.connectorHandler.Dispose();

            if (this._DAL != null)
                this._DAL.Dispose();

        }

    }
}
