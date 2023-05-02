using RestClient.ViewModels;
using System.Windows;

namespace RestClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        private MainWindowViewModel _model;
        public MainWindowView()
        {
            _model = new MainWindowViewModel();

            InitializeComponent();

            this.DataContext = _model;
        }
    }
}
