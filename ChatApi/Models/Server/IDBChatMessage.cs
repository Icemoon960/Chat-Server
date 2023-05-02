using ChatApi.Models.Common;

namespace ChatApi.Models.Server
{
    public interface IDBChatMessage : IChatMessage
    {
        int MessageId { get; set; }
        int SenderId { get; set; }
        int DestChatId { get; set; }
    }
}
