using ChatApi.Models.Server;
using System.Collections.Generic;
using System.Linq;

namespace RestServer.Extensions
{
    public static class DBClientEx
    {
        public static IEnumerable<IDBClient> WithoutPasswords(this IEnumerable<IDBClient> users)
        {
            return users.Select(x => x.WithoutPassword());
        }
        public static IDBClient WithoutPassword(this IDBClient user)
        {
            user.Password = null;
            return user;
        }
    }
}
