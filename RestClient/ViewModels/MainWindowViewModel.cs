using RestClient.Models.UIModels;
using RestClient.Models.ClientModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RestClient.Commands;
using RestChatApi.Client;
using ChatApi.Container;
using System.Threading.Tasks;
using RestApi.Contracts;

namespace RestClient.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            #region TestDaten
            int rnd = new Random().Next(0, int.MaxValue);
            _chatClient = new UIClient { Name = "User" + rnd, Password = "TestPasswort" + rnd };
            Servers.Add(new UIServer { Ip = "localhost", Name = "Default" });
            Servers.Add(new UIServer { Ip = "127.0.0.1", Name = "Default" });
            Users.Add(new Models.ClientModels.UIUser { Name = "User1", Id = 0 });
            Users.Add(new Models.ClientModels.UIUser { Name = "User2", Id = 1 });
            Users.Add(new Models.ClientModels.UIUser { Name = "User2", Id = 2 });
            Members.Add(new Models.ClientModels.UIUser { Name = "User1", Id = 0 });
            Members.Add(new Models.ClientModels.UIUser { Name = "User2", Id = 1 });
            Members.Add(new Models.ClientModels.UIUser { Name = "User2", Id = 2 });
            Chats.Add(new UIChat { Id = 0, ChatName = "Chat 1", CreationDate = DateTime.Now, Creator = new UIUser { Name = "", Id = 0 } });
            Chats.Add(new UIChat { Id = 0, ChatName = "Chat 2", CreationDate = DateTime.Now, Creator = new UIUser { Name = "", Id = 0 } });
            Chats.Add(new UIChat { Id = 0, ChatName = "Chat 3", CreationDate = DateTime.Now, Creator = new UIUser { Name = "", Id = 0 } });
            Chats.Add(new UIChat { Id = 0, ChatName = "Chat 4", CreationDate = DateTime.Now, Creator = new UIUser { Name = "", Id = 0 } });
            Chats.Add(new UIChat { Id = 0, ChatName = "Chat 5", CreationDate = DateTime.Now, Creator = new UIUser { Name = "", Id = 0 } });
            Chats.Add(new UIChat { Id = 0, ChatName = "Chat 6", CreationDate = DateTime.Now, Creator = new UIUser { Name = "", Id = 0 } });

            _displayedchat = new UIChat();

            ChatMessages.Add(new UIChatMessage { ChatId = 0, MessageText = "Test Text", LastEdited = DateTime.Now, Id = 0, Sender = new UIUser { Name = "", Id = 0 } });

            #endregion
            Api = new ChatWebApi();
        }
        private IRestApi Api;

        #region UIFields
        private UIClient _chatClient;

        private BindingList<UIChatMessage> _chatMessages;
        public BindingList<UIChatMessage> ChatMessages
        {
            get
            {
                if (_chatMessages == null)
                {
                    _chatMessages = new BindingList<UIChatMessage>();
                }
                return _chatMessages;
            }
            set { _chatMessages = value; }
        }
        private BindingList<UIServer> _servers;
        public BindingList<UIServer> Servers
        {
            get
            {
                if (_servers == null)
                {
                    _servers = new BindingList<UIServer>();
                }
                return _servers;
            }
            set { _servers = value; }
        }

        private BindingList<UIChat> _chats;
        public BindingList<UIChat> Chats
        {
            get
            {
                if (_chats == null)
                {
                    _chats = new BindingList<UIChat>();
                }
                return _chats;
            }
            set { _chats = value; }
        }

        private BindingList<Models.ClientModels.UIUser> _users;
        public BindingList<Models.ClientModels.UIUser> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new BindingList<Models.ClientModels.UIUser>();
                }
                return _users;
            }
            set { _users = value; }
        }

        private BindingList<Models.ClientModels.UIUser> _members;
        public BindingList<Models.ClientModels.UIUser> Members
        {
            get
            {
                if (_members == null)
                {
                    _members = new BindingList<Models.ClientModels.UIUser>();
                }
                return _members;
            }
            set { _members = value; }
        }
        public string ClientUserName
        {
            get { return _chatClient.Name; }
            set
            {
                _chatClient.Name = value;
                OnPropertyChanged("ClientUserName");
            }
        }

        public string ClientPassword
        {
            get { return _chatClient.Password; }
            set
            {
                _chatClient.Password = value;
                OnPropertyChanged("ClientPassword");
            }
        }
        private UIChat _displayedchat;
        public string ChatName
        {
            get
            {
                if (_displayedchat == null)
                {
                    _displayedchat = new UIChat();
                }
                return _displayedchat.ChatName;
            }
            set
            {
                _displayedchat.ChatName = value;
                OnPropertyChanged("ChatName");
            }
        }

        private string _chatMessageText;
        public string ChatMessageText
        {
            get
            {
                if (_chatMessageText == null)
                {
                    _chatMessageText = string.Empty;
                }
                return _chatMessageText;
            }
            set
            {
                _chatMessageText = value;
                OnPropertyChanged("ChatMessageText");
            }
        }

        private UIChatMessage _selectedMessage;
        public string SelectedMessage
        {
            get
            {
                if (_selectedMessage == null) { _selectedMessage = new UIChatMessage(); }
                return _selectedMessage.MessageText;
            }
            set
            {
                _selectedMessage.MessageText = value;
                OnPropertyChanged("SelectedMessage");
            }
        }

        private Models.ClientModels.UIUser _selectedMember;
        public Models.ClientModels.UIUser SelectedMember
        {
            get
            {
                if (_selectedMember == null) { _selectedMember = new Models.ClientModels.UIUser(); }
                return _selectedMember;
            }
            set
            {
                _selectedMember = value;
                OnPropertyChanged("SelectedMember");
            }
        }

        private Models.ClientModels.UIUser _selectedUser;
        public Models.ClientModels.UIUser SelectedUser
        {
            get
            {
                if (_selectedUser == null) { _selectedUser = new Models.ClientModels.UIUser(); }
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        private UIChat _selectedChat;
        public UIChat SelectedChat
        {
            get
            {
                if (_selectedChat == null) { _selectedChat = new UIChat(); }
                return _selectedChat;
            }
            set
            {
                _selectedChat = value;
                OnPropertyChanged("SelectedChat");
            }
        }

        private UIServer _selectedServer;
        public UIServer SelectedServer
        {
            get
            {
                if (_selectedServer == null) { _selectedServer = new UIServer(); }
                return _selectedServer;
            }
            set
            {
                _selectedServer = value;
                OnPropertyChanged("SelectedServer");
            }
        }
        #endregion
        #region Commands
        private ICommand _addChatMessageCommand;
        public ICommand AddChatMessageCommand
        {
            get
            {
                return _addChatMessageCommand ?? (_addChatMessageCommand = new RelayCommand(
                   x =>
                   {
                       ChatMessages.Add(new UIChatMessage()
                       {
                           ChatId = SelectedChat.Id,
                           LastEdited = DateTime.Now,
                           Sender = new UIUser() { Name = _chatClient.Name, Id = _chatClient.Id },
                           MessageText = ChatMessageText,
                           Id = ChatMessages == null ? ChatMessages[ChatMessages.Count].Id++ : 0
                       });
                   }));
            }

        }
        private ICommand _addServerCommand;
        public ICommand AddServerCommand
        {
            get
            {
                return _addServerCommand ?? (_addServerCommand = new RelayCommand(
                   x =>
                   {
                       Servers.Add(new UIServer());
                   }));
            }

        }
        private AsyncCommand _addChatCommand;
        public AsyncCommand AddChatCommand
        {
            get
            {
                return _addChatCommand ?? (_addChatCommand = new AsyncCommand(SendChatMessage));
            }

        }
        private async Task SendChatMessage()
        {
            await Api.Post("Chat", new ComChat());
        }
        private ICommand _addMemberCommand;
        public ICommand AddMemberCommand
        {
            get
            {
                return _addMemberCommand ?? (_addMemberCommand = new RelayCommand(
                   x =>
                   {
                       Members.Add(new UIUser());
                   }));
            }

        }
        #endregion
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
