using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ItemName = "Tornillos";
            ItemImagePath = @"C:\Users\rbo\Pictures\tornillos.jpg";
            ItemDescription = "Tornifeijfdfdjfhdsj jfdhfjdhf d fhdgfhdsg dhfdgf jdfgd jf dfdsfjsdgf dsjhfgdsjfds fshdgfsdjh f roberto ribes minguez final del texto";
            ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3";
            QuantitySelected = 0;
        }

        [InjectionMethod]
        public void Initialize()
        {
            IncreaseQuantityCommand = new DelegateCommand(OnIncreaseQuantityCommandExecuted);
            DecreaseQuantityCommand = new DelegateCommand(OnDecreaseQuantityCommandExecuted, OnDecreaseQuantityCommandCanExecute);
        }

        #endregion

        #region Commands

        public DelegateCommand IncreaseQuantityCommand { get; set; }

        public DelegateCommand DecreaseQuantityCommand { get; set; }

        #endregion

        #region Properties

        public string ItemDescription { get; set; }

        public string ItemImagePath { get; set; }

        public string ItemName { get; set; }

        public string ItemBarcode { get; set; }

        public string ItemLocation { get; set; }

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

        private void RaisePropertiesChanged()
        {
            RaisePropertyChanged(nameof(QuantitySelected));
            DecreaseQuantityCommand.RaiseCanExecuteChanged();
        }
        #endregion
    }
}
