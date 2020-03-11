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
using Nerob.Client.Modules.Picking.ViewModels;
using Prism.Regions;

using Unity;

namespace Nerob.Client.Modules.Picking.Views
{
    /// <summary>
    /// Interaction logic for StockCountView.xaml
    /// </summary>
    public partial class LocationView : UserControl
    {
        [Dependency]
        public IPickingViewModel PickingViewModel
        {
            get { return (IPickingViewModel)DataContext; }
            set
            {
                DataContext = value;
            }
        }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        [Dependency]
        public IUnityContainer Container { get; set; }
        public LocationView()
        {
            InitializeComponent();
        }

        private void NerobScannerControl_OnScanSubmitted(object sender, string e)
        {
            PickingViewModel.LocationEnteredCommand.Execute(e);
        }

        private void ConfirmButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (nerobScannerControl != null && !string.IsNullOrEmpty(nerobScannerControl.LastSuccessfulScan))
            {
                PickingViewModel.LocationEnteredCommand.Execute(nerobScannerControl.LastSuccessfulScan);
            }
        }
    }
}
