using ChatApi.Models.Common;
using System;

namespace ChatApi.Models.Server
{
    public interface IDBChat : IChat
    {
        int ChatId { get; set; }
        int CreatorId { get; set; }
        DateTime CreationDate { get; set; }
    }
}
