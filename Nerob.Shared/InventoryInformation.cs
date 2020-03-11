using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerob.Shared
{
    public class InventoryInformation
    {
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string ItemBarcode { get; set; }

        public string ItemLocation { get; set; }

        public int QuantityAvailable { get; set; }
    }
}
