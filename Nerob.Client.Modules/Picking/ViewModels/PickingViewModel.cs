using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerob.Client.Modules.Picking.ViewModels
{
    public class PickingViewModel
    {
        public string ItemBarcode { get; set; }

        public string ItemLocation { get; set; }

        public int QuantityPicked { get; set; }
    }
}
