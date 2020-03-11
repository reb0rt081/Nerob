using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Commands;
using Prism.Mvvm;

namespace Nerob.Client.Modules.Picking.ViewModels
{
    public interface IPickingViewModel
    {
        DelegateCommand IncreaseQuantityCommand { get; set; }

        DelegateCommand DecreaseQuantityCommand { get; set; }

        string ItemName { get; set; }

        string ItemDescription { get; set; }

        string ItemImagePath { get; set; }

        string ItemBarcode { get; set; }

        string ItemLocation { get; set; }

        int QuantitySelected { get; set; }
    }
}
