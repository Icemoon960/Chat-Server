using ChatApi.Models.Common;
using System;

namespace ChatApi.Models.Client
{
    public interface IUIChat : IChat
    {
        IUser Creator { get; set; }
        int Id { get; set; }
        DateTime CreationDate { get; set; }
    }
}
