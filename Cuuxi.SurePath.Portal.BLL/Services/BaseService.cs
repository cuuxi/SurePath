using Cuuxi.Toolbox.Framework.Connector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuuxi.SurePath.Portal.BLL.Services
{
    public class BaseService : IRepository
    {
        internal Connector Connector;
        internal Settings settings => this.Connector.settings;


        public BaseService(Connector connector)
        {
            this.Connector = connector;
        }

        public virtual void Dispose()
        {
        }
    }
}
