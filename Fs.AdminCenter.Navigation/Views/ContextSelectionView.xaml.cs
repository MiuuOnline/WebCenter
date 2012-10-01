using System.ComponentModel.Composition;
using System.Windows.Controls;
using Fs.AdminCenter.Infrastructure.Interfaces;

namespace Fs.AdminCenter.Navigation.Views
{
    /// <summary>
    /// Interaction logic for ContextSelectionView.xaml
    /// </summary>
    [Export]
    public partial class ContextSelectionView : UserControl
    {
        [Import]
        public IContextService ContextService
        {
            set { this.DataContext = value; }
        }

        public ContextSelectionView()
        {
            InitializeComponent();
        }
    }
}
