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

namespace Nerob.Client.Modules.Picking.Ribbon
{
    /// <summary>
    /// Interaction logic for PickingRibbon.xaml
    /// </summary>
    public partial class PickingRibbon : UserControl
    {
        public PickingRibbon()
        {
            InitializeComponent();
        }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var mainregion = RegionManager.Regions[Shared.Constants.MainRegion];
            mainregion.NavigationService.Journal.GoBack();
        }
    }
}
