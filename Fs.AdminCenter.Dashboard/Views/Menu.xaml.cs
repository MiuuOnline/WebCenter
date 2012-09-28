using System.ComponentModel.Composition;
using System.Windows.Controls;
using Fs.AdminCenter.Dashboard.ViewModels;

namespace Fs.AdminCenter.Dashboard.Views
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    [Export(typeof(Menu))]
    public partial class Menu : UserControl
    {
        [Import]
        public DashboardViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

        public Menu()
        {
            InitializeComponent();
        }
    }
}
