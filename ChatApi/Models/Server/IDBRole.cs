using ChatApi.Models.Common;

namespace ChatApi.Models.Server
{
    public interface IDBRole : IRole
    {
        int RoleId { get; set; }
    }
}
