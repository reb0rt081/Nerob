using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Nerob.Client.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Exit += ApplicationOnExit;
            Startup += ApplicationOnStartup;
        }

        private void ApplicationOnStartup(object sender, StartupEventArgs e)
        {
            ClientBootStrapper clientBootStrapper = new ClientBootStrapper();
            clientBootStrapper.Run();
        }

        private void ApplicationOnExit(object sender, ExitEventArgs e)
        {
            
        }
    }
}
