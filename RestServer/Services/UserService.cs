using ChatApi.Models.Common;
using RestServer.AuthenticateModels;
using RestServer.Contracts;
using RestServer.Database;
using RestServer.Database.TableModels;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using RestApi.Common.Helpers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ChatApi.Models.Server;
using RestServer.Extensions;
using ChatApi.Models.Communication;
using ChatApi.Container;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace RestServer.Services
{
    public class UserService : IUserService
    {
        private DBContext _context;
        private AppSettings _appsettings;
        public UserService(DBContext context, IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings.Value;
            _context = context;
        }

        public async Task<IComClient> Authenticate(AuthUser user)
        {
            var client = _context.Clients.FirstOrDefault(client => user.Name == client.Name);
            if (client == default(DBClient))
            {
                client = new DBClient() { Name = user.Name, Password = user.Password, ClientRoleId = (int)AuthRole.Ids.User };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, client.ClientId.ToString()),
                    new Claim(ClaimTypes.Name, client.ClientRoleId.ToString())
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            client.Token = tokenHandler.WriteToken(token);
            _context.Clients.Add(client).State = EntityState.Added;
            await _context.SaveChangesAsync();
            var ret = new ComClient(client);
            return new ComClient(client);
        }

        public Task<IEnumerable<IUser>> GetAll()
        {
            throw new NotImplementedException();
        }
        public IDBClient GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
