using Cuuxi.Toolbox.Framework.Connector;

namespace Cuuxi.SurePath.API.BLL.Services
{
    public class BaseService : IRepository
    {
        internal Connector Connector;
        internal Settings settings => this.Connector.settings;

        public BaseService(Connector connector)
        {
            this.Connector = connector;
        }

        public void Dispose()
        {
        }
    }
}
