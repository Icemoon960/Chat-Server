namespace ChatApi.Models.Common
{
    public interface IAuthUser : IUser
    {
        string Password { get; set; }
    }
}
