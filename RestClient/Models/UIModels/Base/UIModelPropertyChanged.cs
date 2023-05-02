using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestClient.Models.ClientModels.Base
{
    public class UIModelPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
