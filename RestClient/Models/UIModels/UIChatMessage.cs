using ChatApi.Common.Client;
using ChatApi.Models.Client;
using RestClient.Models.ClientModels.Base;
using System;

namespace RestClient.Models.UIModels
{
    public class UIChatMessage : UIModelPropertyChanged, IUIChatMessage
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private IUIUser sender;
        public IUIUser Sender
        {
            get { return sender; }
            set
            {
                sender = value;
                OnPropertyChanged("Sender");
            }
        }

        private int chatId;
        public int ChatId
        {
            get { return chatId; }
            set
            {
                chatId = value;
                OnPropertyChanged("ChatId");
            }
        }

        private DateTime lastEdited;
        public DateTime LastEdited
        {
            get { return lastEdited; }
            set
            {
                lastEdited = value;
                OnPropertyChanged("LastEdited");
            }
        }

        private string messageText;
        public string MessageText
        {
            get { return messageText; }
            set
            {
                messageText = value;
                OnPropertyChanged("MessageText");
            }
        }
    }
}
