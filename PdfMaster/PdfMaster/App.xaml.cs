using Dicgo.Common.Helpers;
using Master.Models;
using System.Configuration;
using System.Data;
using System.Windows;
using Application = System.Windows.Application;

namespace Master
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
        }
    }

}
