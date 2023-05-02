using ChatApi.Models.Communication;
using ChatApi.Models.Server;

namespace ChatApi.Container
{
    public class ComClient : IComClient
    {
        public int ClientId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int ClientRoleId { get; set; }
        public ComClient() { }
        public ComClient(IDBClient client) 
        {
            ClientId = client.ClientId;
            Token = client.Token;
            Password = client.Password;
            Name = client.Name;
            ClientRoleId = client.ClientRoleId;
        }
    }
}