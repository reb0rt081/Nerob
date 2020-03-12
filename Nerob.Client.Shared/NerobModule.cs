using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace Nerob.Client.Shared
{
    public abstract class NerobModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);

        public abstract NerobModuleInfo GetModuleInfo();

        public abstract void OnInitialized(IContainerProvider containerProvider);
    }
}
