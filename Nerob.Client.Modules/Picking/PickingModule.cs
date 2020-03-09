using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nerob.Client.Core;
using Nerob.Client.Modules.Picking.Ribbon;
using Nerob.Client.Modules.Picking.ViewModels;
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
            containerRegistry.RegisterForNavigation<PickingRibbon>();
            containerRegistry.RegisterForNavigation<PickingView>();
            containerRegistry.RegisterForNavigation<StockCountView>();
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            PickingViewModel pickingViewModel = new PickingViewModel();
            Container.RegisterInstance<IPickingViewModel>(pickingViewModel, new ContainerControlledLifetimeManager());
            Container.BuildUp(pickingViewModel);

            this.RegisterViewInRegionAndContainer<PickingView>(Shared.Constants.MainRegion, Shared.Constants.PickingView);

            //RegionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => Container.Resolve<PickingView>(Shared.Constants.PickingView));

            this.RegisterViewInRegionAndContainer<StockCountView>(Shared.Constants.MainRegion,
                Shared.Constants.StockCountView);

            //RegionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => Container.Resolve<StockCountView>(Shared.Constants.StockCountView));

            this.RegisterViewInRegionAndContainer<PickingRibbon>(Shared.Constants.RibbonRegion, Shared.Constants.PickingRibbon);
        }
    }
}
