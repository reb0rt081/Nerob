using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerob.Client.Modules.Picking.ViewModels
{
    public class PickingViewModel : IPickingViewModel
    {
        #region Constructor

        public PickingViewModel()
        {
            ItemName = "Tornillos";
            ItemImagePath = @"C:\Users\rbo\Pictures\tornillos.jpg";
            ItemDescription = "Tornifeijfdfdjfhdsj jfdhfjdhf d fhdgfhdsg dhfdgf jdfgd jf dfdsfjsdgf dsjhfgdsjfds fshdgfsdjh f roberto ribes minguez final del texto";
            ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3";
            QuantitySelected = 0;
        }

        #endregion

        #region Properties

        public string ItemDescription { get; set; }

        public string ItemImagePath { get; set; }

        public string ItemName { get; set; }

        public string ItemBarcode { get; set; }

        public string ItemLocation { get; set; }

        public int QuantitySelected { get; set; }

        #endregion

    }
}
