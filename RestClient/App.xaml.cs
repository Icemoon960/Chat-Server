using System.Runtime.InteropServices;
using System.Windows;

namespace RestClient
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindowView wnd = new MainWindowView();
            wnd.Title = "Chat Client";
            wnd.Show();
        }
    }
}
