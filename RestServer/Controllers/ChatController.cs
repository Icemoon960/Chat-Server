using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestServer.Database.TableModels;
using RestServer.Database;
using RestServer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using RestServer.AuthenticateModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Primitives;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace RestServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ChatController : BaseController<DBChat, ChatController>
    {
        public ChatController(ILogger<ChatController> logger, DBContext context) : base(context, logger)
        {
            _dbSet = context.Chats;
        }

        [HttpGet]
        public void GetAll()
        {
            //Task<List<DBChat>
            _logger.LogTrace(MethodBase.GetCurrentMethod().Name);
            StringValues token = new StringValues();
            Request.Headers.TryGetValue("Authorization", out token);
            var t = _context.Clients.Where(client => client.Token == token).FirstOrDefault();
        }
        public override async void Post(object json)
        {
            DBChat entity = JsonConvert.DeserializeObject<DBChat>(json.ToString());
            _logger.LogTrace(MethodBase.GetCurrentMethod().Name + entity.ToString());
            _dbSet.Add(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
    }
}
