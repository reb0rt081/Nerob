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
    public class PickingViewModel : BindableBase, IPickingViewModel
    {
        #region Constructor and Initialize

        public PickingViewModel()
        {
            ResetView();
        }

        [InjectionMethod]
        public void Initialize()
        {
            ConfirmPickCommand = new DelegateCommand(OnPickConfirmCommandExecuted, OnPickConfirmCommandCanExecute);
            IncreaseQuantityCommand = new DelegateCommand(OnIncreaseQuantityCommandExecuted, OnIncreaseQuantityCommandCanExecute);
            DecreaseQuantityCommand = new DelegateCommand(OnDecreaseQuantityCommandExecuted, OnDecreaseQuantityCommandCanExecute);
        }

        #endregion

        #region Commands

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
            return InventoryInformation!= null && QuantitySelected < InventoryInformation.QuantityAvailable ;
        }

        private void OnPickConfirmCommandExecuted()
        {
            RegionManager.RequestNavigate(Shared.Constants.MainRegion, typeof(StockCountView).Name);
        }

        private bool OnPickConfirmCommandCanExecute()
        {
            return QuantitySelected >= 0 && InventoryInformation != null && InventoryInformation.QuantityAvailable > 0;
        }

        private void RaisePropertiesChanged()
        {
            RaisePropertyChanged(nameof(QuantitySelected));
            DecreaseQuantityCommand.RaiseCanExecuteChanged();
            IncreaseQuantityCommand.RaiseCanExecuteChanged();
            ConfirmPickCommand.RaiseCanExecuteChanged();
        }

        #endregion
    }
}
