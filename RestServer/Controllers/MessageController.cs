using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestServer.Database.TableModels;
using RestServer.Database;
using RestServer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using RestServer.AuthenticateModels;

namespace RestServer.Controllers
{
    [Authorize(Roles = AuthRole.User)]
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageController : BaseController<DBChatMessage, MessageController>
    {
        public MessageController(ILogger<MessageController> logger, DBContext context) : base(context, logger)
        {
            _dbSet = context.ChatMessages;
        }
    }
}
