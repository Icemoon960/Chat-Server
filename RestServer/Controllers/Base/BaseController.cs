using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestServer.AuthenticateModels;
using RestServer.Contracts;
using RestServer.Database;
using System.Reflection;
using System.Threading.Tasks;

namespace RestServer.Controllers.Base
{
    [AllowAnonymous]
    public abstract class BaseController<DBEntity, ImpController> : ControllerBase, IController<DBEntity> where DBEntity : class
    {
        internal DBContext _context;
        internal DbSet<DBEntity> _dbSet;

        public readonly ILogger<ImpController> _logger;

        public BaseController(DBContext context, ILogger<ImpController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [Authorize(Roles = AuthRole.User)]
        [HttpDelete]
        public virtual async void DeleteByID(int id){
            _logger.LogTrace(MethodBase.GetCurrentMethod().Name + "id = " + id);
            _dbSet.Remove(await _dbSet.FindAsync(id));
            await _context.SaveChangesAsync();
        }
        [Authorize(Roles = AuthRole.User)]
        [HttpGet]
        public virtual async Task<DBEntity> GetByID(int id){
            _logger.LogTrace(MethodBase.GetCurrentMethod().Name + "id = " + id); 
            return await _dbSet.FindAsync(id);
        }
        [Authorize(Roles = AuthRole.User)]
        [HttpPost]
        public virtual async void Post(object json){
            DBEntity entity = JsonConvert.DeserializeObject<DBEntity>(json.ToString());
            _logger.LogTrace(MethodBase.GetCurrentMethod().Name + entity.ToString());
            _dbSet.Add(entity).State = EntityState.Added;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
        }
        [Authorize(Roles = AuthRole.User)]
        [HttpPatch]
        public virtual async void Update([FromHeader] DBEntity entity){
            _logger.LogTrace(MethodBase.GetCurrentMethod().Name + entity.ToString());
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
