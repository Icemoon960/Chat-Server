
using ChatApi.Models.Client;
using ChatApi.Models.Common;

namespace ChatApi.Common.Client
{
    public interface IUIChatMessage : IChatMessage
    {
        int Id { get; set; }
        IUIUser Sender { get; set; }
        int ChatId { get; set; }
    }
}
