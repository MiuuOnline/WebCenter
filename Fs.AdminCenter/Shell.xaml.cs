using System.ComponentModel.Composition;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;

namespace Fs.AdminCenter
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    [Export(typeof(Shell))]
    public partial class Shell : Window
    {
        [Import(AllowRecomposition = false)]
        private IModuleManager moduleManager;

        public Shell()
        {
            InitializeComponent();
        }
    }
}
