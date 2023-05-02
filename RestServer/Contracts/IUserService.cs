using ChatApi.Models.Communication;
using RestServer.AuthenticateModels;
using System.Threading.Tasks;

namespace RestServer.Contracts
{
    public interface IUserService
    {
        Task<IComClient> Authenticate(AuthUser user);
    }
}
