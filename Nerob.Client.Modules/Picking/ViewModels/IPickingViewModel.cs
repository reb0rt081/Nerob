using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerob.Client.Modules.Picking.ViewModels
{
    public interface IPickingViewModel
    {
        string ItemName { get; set; }

        string ItemImagePath { get; set; }

        string ItemBarcode { get; set; }

        string ItemLocation { get; set; }

        int QuantityPicked { get; set; }
    }
}
