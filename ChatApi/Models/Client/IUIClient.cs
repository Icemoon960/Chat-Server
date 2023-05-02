using ChatApi.Models.Common;

namespace ChatApi.Models.Client
{
    public interface IUIClient : IUser
    {           
        string Password { get; set; }
        int Id { get; set; }
    }
}
