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
            containerRegistry.RegisterForNavigation<LocationView>();
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            this.RegisterViewAndViewModelInRegionAndContainer<LocationView, IPickingViewModel, PickingViewModel>(new PickingViewModel(), Shared.Constants.MainRegion, Shared.Constants.LocationView);

            this.RegisterViewInRegionAndContainer<PickingView>(Shared.Constants.MainRegion,
                Shared.Constants.PickingView);

            this.RegisterViewInRegionAndContainer<PickingRibbon>(Shared.Constants.RibbonRegion, Shared.Constants.PickingRibbon);
        }
    }
}
