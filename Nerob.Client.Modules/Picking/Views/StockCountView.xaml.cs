using System;
using System.Collections.Generic;
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

using Prism.Regions;

using Unity;

namespace Nerob.Client.Modules.Picking.Views
{
    /// <summary>
    /// Interaction logic for StockCountView.xaml
    /// </summary>
    public partial class StockCountView : UserControl
    {
        [Dependency]
        public IRegionManager RegionManager { get; set; }

        [Dependency]
        public IUnityContainer Container { get; set; }
        public StockCountView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RegionManager.RequestNavigate(Shared.Constants.MainRegion, typeof(PickingView).Name);
        }
    }
}
