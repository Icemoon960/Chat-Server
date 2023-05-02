using ChatApi.Models.Common;

namespace ChatApi.Models.Server
{
    public interface IDBClient : IUser
    {
        string Token { get; set; }
        string Password { get; set; }
        int ClientRoleId { get; set; }
        int ClientId { get; set; }
    }
}
