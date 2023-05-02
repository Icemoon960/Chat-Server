using ChatApi.Models.Client;
using RestClient.Models.ClientModels.Base;

namespace RestClient.Models.UIModels
{
    public class UIServer : UIModelPropertyChanged, IUIServer
    {
        private string ip;
        public string Ip
        {
            get { return ip; }
            set
            {
                ip = value;
                OnPropertyChanged("Ip");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
