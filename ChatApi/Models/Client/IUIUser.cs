using ChatApi.Models.Common;

namespace ChatApi.Models.Client
{
    public interface IUIUser : IUser, IRole
    {
        int Id { get; set; }
    }
}
