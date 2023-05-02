using ChatApi.Models.Communication;
using System;

namespace ChatApi.Container
{
    public class ComChat : IComChat
    {
        public int ChatId { get; set; }
        public int CreatorId { get; set; }
        public string ChatName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
