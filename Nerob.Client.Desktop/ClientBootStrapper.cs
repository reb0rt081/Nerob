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
using Unity.Lifetime;

namespace Nerob.Client.Desktop
{
    /// <summary>
    /// Following pattern from:
    /// Link1: https://prismlibrary.com/docs/wpf/legacy/Composing-the-UI.html
    /// Link2: https://github.com/PrismLibrary/Prism-Samples-Wpf
    /// </summary>
    public class ClientBootStrapper : UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            //  This method for some reason creates a double view if we tell the app to show the main window
            base.InitializeShell();
            //Application.Current.MainWindow.Show();
        }

        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);

            CheckUniqueInstanceIsRunning();

            LoadModules();
        }

        public void LoadModules()
        {
            IRegionManager regionManager =
                Container.Resolve<IRegionManager>();

            PickingView pickingView = new PickingView();
            Container.RegisterInstance<PickingView>(Shared.Constants.PickingView, pickingView, new ContainerControlledLifetimeManager());
            Container.BuildUp(pickingView);
            
            regionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => Container.Resolve<PickingView>(Shared.Constants.PickingView));
            
            StockCountView stockCountView = new StockCountView();
            Container.RegisterInstance<StockCountView>(stockCountView, new ContainerControlledLifetimeManager());
            Container.BuildUp(stockCountView);

            regionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => Container.Resolve<StockCountView>(Shared.Constants.StockCountView));
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
