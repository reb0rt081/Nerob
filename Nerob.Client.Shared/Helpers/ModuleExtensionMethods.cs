﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nerob.Client.Core;
using Unity.Lifetime;
using Unity;

namespace Nerob.Client.Shared.Helpers
{
    public static class ModuleExtensionMethods
    {
        public static void RegisterViewInRegion<T>(this NerobModule nerobModule, string regionName, string viewName)
        {
            nerobModule.RegionManager.Regions[regionName].Add(nerobModule.Container.Resolve(typeof(T), viewName), viewName);
        }

        public static void RegisterViewInRegionAndContainer<T>(this NerobModule nerobModule, string regionName,
            string viewName)
        {
            nerobModule.Container.RegisterType(typeof(T), typeof(T), viewName, new ContainerControlledLifetimeManager());

            RegisterViewInRegion<T>(nerobModule, regionName, viewName);
        }

        public static void RegisterViewAndViewModelInRegionAndContainer<T1, T2>(this NerobModule nerobModule, T2 viewModel, string regionName, string viewName)
        {
            nerobModule.Container.RegisterInstance<T2>(viewModel, new ContainerControlledLifetimeManager());
            nerobModule.Container.BuildUp(viewModel);

            RegisterViewInRegionAndContainer<T1>(nerobModule, regionName, viewName);
        }
    }
}
