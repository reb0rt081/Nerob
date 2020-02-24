using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nerob.Client.Modules.Picking.Views;
using Nerob.Domain;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

using Unity;
using Unity.Lifetime;

namespace Nerob.Client.Modules.Picking
{
    public class PickingModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PickingView>();
            containerRegistry.RegisterForNavigation<StockCountView>();
            IUnityContainer container = containerRegistry.GetContainer();

            IRegionManager regionManager =
                container.Resolve<IRegionManager>();

            PickingView pickingView = new PickingView();
            container.RegisterInstance<PickingView>(Shared.Constants.PickingView, pickingView, new ContainerControlledLifetimeManager());
            container.BuildUp(pickingView);

            regionManager.Regions[Shared.Constants.MainRegion].Add(container.Resolve<PickingView>(Shared.Constants.PickingView), Shared.Constants.PickingView);
            //regionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => container.Resolve<PickingView>(Shared.Constants.PickingView));
            
            StockCountView stockCountView = new StockCountView();
            container.RegisterInstance<StockCountView>(stockCountView, new ContainerControlledLifetimeManager());
            container.BuildUp(stockCountView);

            //regionManager.RegisterViewWithRegion(Shared.Constants.MainRegion, () => container.Resolve<StockCountView>(Shared.Constants.StockCountView));
            regionManager.Regions[Shared.Constants.MainRegion].Add(container.Resolve<StockCountView>(Shared.Constants.StockCountView), Shared.Constants.StockCountView);

        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }
    }
}
