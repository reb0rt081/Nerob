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
        }

        #endregion

        #region Properties

        public string ItemImagePath { get; set; }

        public string ItemName { get; set; }

        public string ItemBarcode { get; set; }

        public string ItemLocation { get; set; }

        public int QuantityPicked { get; set; }

        #endregion

    }
}
