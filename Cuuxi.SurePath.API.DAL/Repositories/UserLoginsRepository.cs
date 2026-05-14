using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.API.DAL.Repositories
{
    public class UserLoginsRepository : BaseRepository
    {
        public UserLoginsRepository(Connector connector) : base(connector) { }

        public Task<UserLoginDto?> FindAsync(string provider, string providerKey) =>
            Connector.Dal.UserLogins.FindAsync(provider, providerKey);

        public Task<string?> GetSecretAsync(string provider, string providerKey) =>
            Connector.Dal.UserLogins.GetSecretAsync(provider, providerKey);
    }
}
