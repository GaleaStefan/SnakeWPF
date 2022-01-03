using System.Windows;

namespace SnakeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = new(new());
            MainWindow window = new();
            window.DataContext = mainWindowViewModel;
            window.Show();
        }
    }
}
