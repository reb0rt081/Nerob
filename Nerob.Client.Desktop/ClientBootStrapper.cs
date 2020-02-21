using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using CommonServiceLocator;
using Nerob.Client.Modules.Picking;
using Nerob.Client.Modules.Picking.Views;
using Nerob.Domain;

using Prism.Regions;
using Prism.Unity;
using Unity;

namespace Nerob.Client.Desktop
{
    public class ClientBootStrapper : UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }

        public void CheckUniqueInstanceIsRunning()
        {
            string processName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (System.Diagnostics.Process.GetProcessesByName(processName).Count() > 1)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}
