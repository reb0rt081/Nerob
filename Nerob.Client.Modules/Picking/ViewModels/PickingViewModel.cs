using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nerob.Shared;

using Prism.Commands;
using Prism.Mvvm;

using Unity;

namespace Nerob.Client.Modules.Picking.ViewModels
{
    public class PickingViewModel : BindableBase, IPickingViewModel
    {
        #region Constructor and Initialize

        public PickingViewModel()
        {
            InventoryInformation = new InventoryInformation()
            {
                ItemName = "Tornillos",
                ItemDescription = "Tornifeijfdfdjfhdsj jfdhfjdhf d fhdgfhdsg dhfdgf jdfgd jf dfdsfjsdgf dsjhfgdsjfds fshdgfsdjh f roberto ribes minguez final del texto",
                ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3",
                QuantityAvailable = 10,
                ItemBarcode = "1011"
            };
            
            ItemImagePath = @"C:\Users\rbo\Pictures\tornillos.jpg";
            QuantitySelected = 0;
        }

        [InjectionMethod]
        public void Initialize()
        {
            IncreaseQuantityCommand = new DelegateCommand(OnIncreaseQuantityCommandExecuted, OnIncreaseQuantityCommandCanExecute);
            DecreaseQuantityCommand = new DelegateCommand(OnDecreaseQuantityCommandExecuted, OnDecreaseQuantityCommandCanExecute);
        }

        #endregion

        #region Commands

        public DelegateCommand IncreaseQuantityCommand { get; set; }

        public DelegateCommand DecreaseQuantityCommand { get; set; }

        #endregion

        #region Properties

        public InventoryInformation InventoryInformation { get; set; }

        public string ItemImagePath { get; set; }

        public int QuantitySelected { get; set; }

        #endregion

        #region Private methods

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

        private void RaisePropertiesChanged()
        {
            RaisePropertyChanged(nameof(QuantitySelected));
            DecreaseQuantityCommand.RaiseCanExecuteChanged();
            IncreaseQuantityCommand.RaiseCanExecuteChanged();
        }
        #endregion
    }
}
