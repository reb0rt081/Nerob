using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nerob.Client.Core;
using Nerob.Client.Modules.Picking.Views;
using Nerob.Client.Shared.Helpers;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

using Unity;
using Unity.Lifetime;

namespace Nerob.Client.Modules.Picking
{
    public class PickingModule : NerobModule
    {
        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PickingView>();
            containerRegistry.RegisterForNavigation<StockCountView>();
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            IUnityContainer container = containerProvider.GetContainer();

            IRegionManager regionManager =
                container.Resolve<IRegionManager>();

            PickingView pickingView = new PickingView();
            container.RegisterInstance<PickingView>(Shared.Constants.PickingView, pickingView, new ContainerControlledLifetimeManager());
            container.BuildUp(pickingView);
            this.RegisterViewInRegion<PickingView>(Shared.Constants.MainRegion, Shared.Constants.PickingView);

            //regionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => container.Resolve<PickingView>(Shared.Constants.PickingView));

            StockCountView stockCountView = new StockCountView();
            container.RegisterInstance<StockCountView>(stockCountView, new ContainerControlledLifetimeManager());
            container.BuildUp(stockCountView);
            this.RegisterViewInRegion<StockCountView>(Shared.Constants.MainRegion, Shared.Constants.StockCountView);
            
            //regionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => container.Resolve<StockCountView>(Shared.Constants.StockCountView));
        }
    }
}
