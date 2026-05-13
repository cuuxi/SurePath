using Cuuxi.Toolbox.Framework.Connector;

namespace Cuuxi.SurePath.DAL.Repositories
{
    public class BaseRepository : IRepository
    {
        internal Connector Connector;
        internal Settings settings => this.Connector.settings;

        public BaseRepository(Connector connector)
        {
            this.Connector = connector;
        }

        public void Dispose()
        {
        }
    }
}
