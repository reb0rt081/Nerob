using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nerob.Client.Shared;

namespace Nerob.Client.Controls
{
    /// <summary>
    /// Interaction logic for NerobBackRibbonButton.xaml
    /// </summary>
    public partial class NerobBackRibbonButton : RibbonButton
    {
        public NerobBackRibbonButton()
        {
            InitializeComponent();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (!(DataContext is NerobModule))
            {
                throw new InvalidCastException($"{nameof(NerobBackRibbonButton)} needs a {nameof(DataContext)} of type {typeof(NerobModule)}. Actual type is {DataContext.GetType()}");
            }
        }
    }
}
