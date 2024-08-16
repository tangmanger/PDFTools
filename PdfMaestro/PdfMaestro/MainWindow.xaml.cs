using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PdfMaestro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, CloseExecute));
            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, MaximizeExecute));
            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, RestoreExecute));
            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, MinimizeExecute));
            this.StateChanged += MainWindow_StateChanged;
            max.Visibility = Visibility.Visible;
            normal.Visibility = Visibility.Collapsed;
        }

        private void MainWindow_StateChanged(object? sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                max.Visibility = Visibility.Collapsed;
                normal.Visibility = Visibility.Visible;
            }
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                max.Visibility = Visibility.Visible;
                normal.Visibility = Visibility.Collapsed;
            }
        }

        private void MinimizeExecute(object sender, ExecutedRoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RestoreExecute(object sender, ExecutedRoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void MaximizeExecute(object sender, ExecutedRoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void CloseExecute(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}