using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nerob.Client.Modules.Picking.Views;
using Nerob.Shared;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using Unity;

namespace Nerob.Client.Modules.Picking.ViewModels
{
    public class PickingViewModel : BindableBase, INavigationAware, IPickingViewModel
    {
        #region Constructor and Initialize

        public PickingViewModel()
        {
            ResetView();
        }

        [InjectionMethod]
        public void Initialize()
        {
            LocationEnteredCommand = new DelegateCommand<string>(OnLocationEnteredCommandExecuted);
            BarcodeEnteredCommand = new DelegateCommand<string>(OnBarcodeEnteredCommandExecuted);
            ConfirmPickCommand = new DelegateCommand(OnPickConfirmCommandExecuted, OnPickConfirmCommandCanExecute);
            IncreaseQuantityCommand = new DelegateCommand(OnIncreaseQuantityCommandExecuted, OnIncreaseQuantityCommandCanExecute);
            DecreaseQuantityCommand = new DelegateCommand(OnDecreaseQuantityCommandExecuted, OnDecreaseQuantityCommandCanExecute);
        }

        #endregion

        #region Commands

        public DelegateCommand<string> LocationEnteredCommand { get; set; }

        public DelegateCommand<string> BarcodeEnteredCommand { get; set; }

        public DelegateCommand ConfirmPickCommand { get; set; }

        public DelegateCommand IncreaseQuantityCommand { get; set; }

        public DelegateCommand DecreaseQuantityCommand { get; set; }

        #endregion

        #region Properties

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public InventoryInformation InventoryInformation { get; set; }

        public string ItemImagePath { get; set; }

        public int QuantitySelected { get; set; }

        #endregion

        #region Private methods

        private void ResetView()
        {
            InventoryInformation = new InventoryInformation()
            {
                ItemName = "Scan Item",
                ItemDescription = string.Empty,
                ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3",
                QuantityAvailable = 0,
                ItemBarcode = string.Empty
            };

            ItemImagePath = @"pack://application:,,,/Nerob.Client.Shared;component/Images/questionMark.png";
            QuantitySelected = 0;
        }

        private void OnBarcodeEnteredCommandExecuted(string barcode)
        {
            if(InventoryInformation == null || InventoryInformation.ItemBarcode != barcode)
            {
                InventoryInformation = new InventoryInformation()
                {
                    ItemName = "Tornillos",
                    ItemDescription = @"D:\TGW\bin\PDEnvironment\SCOTe.Agent\v2\Projects\BuildSolution.proj(221,5): warning : CompleteTransportRequest.cs(15,18): warning CS1591: Missing XML comment for publicly visible type or member 'CompleteTransportRequest' [D:\_B\6837055\B\8\Products\SharedCode\ManualTransports\ManualTransports.Facade.Messages\ManualTransports.Facade.Messages.csproj] D:\TGW\bin\PDEnvironment\SCOTe.Agent\v2\Projects\BuildSolution.proj(221, 5): warning : CompleteTransportResponse.cs(16, 18): warning CS1591: Missing XML comment for publicly visible type or member 'CompleteTransportResponse'[D:\_B\6837055\B\8\Products\SharedCode\ManualTransports\ManualTransports.Facade.Messages\ManualTransports.Facade.Messages.csproj]",
                    ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3",
                    QuantityAvailable = 10,
                    ItemBarcode = barcode
                };

                ItemImagePath = @"C:\Users\rbo\Pictures\tornillos.jpg";
                QuantitySelected = 1;
            }
            else
            {
                if (IncreaseQuantityCommand.CanExecute())
                {
                    IncreaseQuantityCommand.Execute();
                }
            }

            RaisePropertiesChanged();
        }

        private void OnLocationEnteredCommandExecuted(string barcode)
        {
            if (!string.IsNullOrEmpty(barcode))
            {
                RaisePropertiesChanged();
                
                RegionManager.RequestNavigate(Shared.Constants.MainRegion, typeof(PickingView).Name);
            }
        }

        private void OnIncreaseQuantityCommandExecuted()
        {
            QuantitySelected++;
            RaisePropertiesChanged();
        }

        private void OnDecreaseQuantityCommandExecuted()
        {
            QuantitySelected--;
            RaisePropertiesChanged();
        }

        private bool OnDecreaseQuantityCommandCanExecute()
        {
            return QuantitySelected > 0;
        }

        private bool OnIncreaseQuantityCommandCanExecute()
        {
            return InventoryInformation!= null && QuantitySelected < InventoryInformation.QuantityAvailable;
        }

        private void OnPickConfirmCommandExecuted()
        {
            ResetView();

            RaisePropertiesChanged();

            RegionManager.RequestNavigate(Shared.Constants.MainRegion, typeof(LocationView).Name);
        }

        private bool OnPickConfirmCommandCanExecute()
        {
            return QuantitySelected > 0 && InventoryInformation != null && InventoryInformation.QuantityAvailable > 0;
        }

        private void RaisePropertiesChanged()
        {
            RaisePropertyChanged(nameof(InventoryInformation));
            RaisePropertyChanged(nameof(ItemImagePath));
            RaisePropertyChanged(nameof(QuantitySelected));
            DecreaseQuantityCommand.RaiseCanExecuteChanged();
            IncreaseQuantityCommand.RaiseCanExecuteChanged();
            ConfirmPickCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region Navigation

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            RaisePropertiesChanged();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        #endregion

    }
}
