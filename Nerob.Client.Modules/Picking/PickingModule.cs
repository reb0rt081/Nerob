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
            PickingView pickingView = new PickingView();
            Container.RegisterInstance<PickingView>(Shared.Constants.PickingView, pickingView, new ContainerControlledLifetimeManager());
            Container.BuildUp(pickingView);
            this.RegisterViewInRegion<PickingView>(Shared.Constants.MainRegion, Shared.Constants.PickingView);

            //RegionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => Container.Resolve<PickingView>(Shared.Constants.PickingView));

            StockCountView stockCountView = new StockCountView();
            Container.RegisterInstance<StockCountView>(stockCountView, new ContainerControlledLifetimeManager());
            Container.BuildUp(stockCountView);
            this.RegisterViewInRegion<StockCountView>(Shared.Constants.MainRegion, Shared.Constants.StockCountView);
            
            //RegionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => Container.Resolve<StockCountView>(Shared.Constants.StockCountView));
        }
    }
}
