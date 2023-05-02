using ChatApi.Models.Common;
using ChatApi.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Enums
{
    public enum Role:int
    {
        Unknown = -1,
        Admin = 0,
        User = 1,
    }

    public static class RoleProvider
    {
        public const string Unknown = "Unknown";
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
