using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nerob.Shared;

using Prism.Commands;
using Prism.Mvvm;

namespace Nerob.Client.Modules.Picking.ViewModels
{
    public interface IPickingViewModel
    {
        DelegateCommand ConfirmPickCommand { get; set; }

        DelegateCommand IncreaseQuantityCommand { get; set; }

        DelegateCommand DecreaseQuantityCommand { get; set; }

        
        string ItemImagePath { get; set; }

        InventoryInformation InventoryInformation { get; set; }

        int QuantitySelected { get; set; }
    }
}
