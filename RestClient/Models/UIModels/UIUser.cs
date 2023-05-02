using ChatApi.Models.Client;
using RestClient.Models.ClientModels.Base;

namespace RestClient.Models.ClientModels
{
    public class UIUser : UIModelPropertyChanged, IUIUser
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

        private string roleName;
        public string RoleName
        {
            get { return roleName; }
            set
            {
                roleName = value;
                OnPropertyChanged("RoleName");
            }
        }
    }
}
