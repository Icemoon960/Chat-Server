using ChatApi.Models.Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestServer.AuthenticateModels;
using RestServer.Contracts;
using RestServer.Controllers.Base;
using RestServer.Database;
using RestServer.Database.TableModels;
using RestServer.Services;
using System.Threading.Tasks;

namespace RestServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController: BaseController<DBClient,UserController>
    {
        public UserService _userService;
        public UserController(ILogger<UserController> logger, DBContext context, IUserService userService) : base(context, logger)
        {
            _dbSet = context.Clients;
            _userService = (UserService)userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IComClient Authenticate(object json)
        {
            var client = JsonConvert.DeserializeObject<AuthUser>(json.ToString());
            if(client == default(AuthUser) || client.Name == string.Empty || client.Password == string.Empty) 
            {
                return null;
            }
            var dbClient = _userService.Authenticate(client).Result;
            return dbClient;
        }

        [Authorize(Roles = AuthRole.Admin)]
        public override void DeleteByID(int id)
        {
            throw new System.NotImplementedException();
        }

        [Authorize(Roles = AuthRole.Admin)]
        public override Task<DBClient> GetByID(int id)
        {
            throw new System.NotImplementedException();
        }

        [Authorize(Roles = AuthRole.Admin)]
        public override void Post(object json)
        {
            throw new System.NotImplementedException();
        }

        [Authorize(Roles = AuthRole.Admin)]
        public override void Update(DBClient entityToUpdate)
        {
            throw new System.NotImplementedException();
        }


    }
}
