using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Nerob.Client.Modules.Picking.ViewModels;

using Prism.Regions;

using Unity;

namespace Nerob.Client.Modules.Picking.Views
{
    /// <summary>
    /// Interaction logic for PickingView.xaml
    /// </summary>
    public partial class PickingView : UserControl
    {
        [Dependency]
        public IRegionManager RegionManager { get; set; }

        [Dependency]
        public IPickingViewModel PickingViewModel { get; set; }

        public PickingView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if(PickingViewModel != null)
            {
                RegionManager.RequestNavigate(Shared.Constants.MainRegion, typeof(StockCountView).Name);
            }
        }
    }
}
