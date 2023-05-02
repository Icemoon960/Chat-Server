using ChatApi.Models.Communication;
using System;

namespace ChatApi.Container
{
    public class ComChatMessage : IComChatMessage
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int DestChatId { get; set; }
        public DateTime LastEdited { get; set; }
        public string MessageText { get; set; }
    }
}