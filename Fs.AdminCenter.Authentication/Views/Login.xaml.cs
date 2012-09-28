using System.ComponentModel.Composition;
using System.Windows.Controls;
using Fs.AdminCenter.Authentication.ViewModels;
using Microsoft.Practices.Prism.Modularity;

namespace Fs.AdminCenter.Authentication.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    [Export(typeof(Login))]
    public partial class Login : UserControl
    {
        [Import]
        public AuthenticationViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

        public Login()
        {
            InitializeComponent();
        }
    }
}
