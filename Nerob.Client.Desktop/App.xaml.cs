﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using Nerob.Client.Modules.Picking;
using Nerob.Client.Modules.Picking.Views;
using Nerob.Client.Shared;

using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

using Unity;

namespace Nerob.Client.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected MainMenuView MainMenu { get; set; }

        public App()
        {
            MainMenu = new MainMenuView();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<PickingModule>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();

            IRegionManager regionManager = Container.Resolve<IRegionManager>();
            var module = Container.Resolve<PickingModule>();
            
            if(module is NerobModule nerobModule)
            {
                var moduleInfo = nerobModule.GetModuleInfo();

                Button pickingButton = GetModuleMenuButton(regionManager, moduleInfo.Name, moduleInfo.ImageUri);

                MainMenu.menuPanel.Children.Add(pickingButton);
            }

            regionManager.Regions[Shared.Constants.MainRegion].Add(MainMenu, Shared.Constants.MainMenuView);

            regionManager.RequestNavigate(Shared.Constants.MainRegion, typeof(MainMenuView).Name);
        }

        protected Button GetModuleMenuButton(IRegionManager regionManager, string buttonText, string imageUri)
        {
            Button pickingButton = new Button();
            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical
            };
            pickingButton.Content = stackPanel;
            stackPanel.Children.Add(new Label()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Content = buttonText
            });
            stackPanel.Children.Add(new Image() { Width = 200, Height = 200, Source = new BitmapImage(new Uri(imageUri)) });
            pickingButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            pickingButton.Style = MainMenu.mainGrid.Resources["MenuButtonStyle"] as Style;
            pickingButton.Command = new DelegateCommand(() => regionManager.RequestNavigate(Shared.Constants.MainRegion, typeof(LocationView).Name));

            return pickingButton;
        }

    }
}
