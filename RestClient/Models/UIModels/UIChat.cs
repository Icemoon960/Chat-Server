using ChatApi.Models.Client;
using ChatApi.Models.Common;
using RestClient.Models.ClientModels.Base;
using System;

namespace RestClient.Models.UIModels
{
    public class UIChat : UIModelPropertyChanged, IUIChat
    {
        private string name;
        public string ChatName
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

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

        private IUser creator;
        public IUser Creator
        {
            get { return creator; }
            set
            {
                creator = value;
                OnPropertyChanged("Creator");
            }
        }

        private DateTime creationDate;
        public DateTime CreationDate
        {
            get { return creationDate; }
            set
            {
                creationDate = value;
                OnPropertyChanged("CreationDate");
            }
        }
    }
}
