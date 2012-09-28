using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using Fs.AdminCenter.Infrastructure.Region;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;

namespace Fs.AdminCenter.Authentication.ViewModels
{
    [Export(typeof(AuthenticationViewModel))]
    public class AuthenticationViewModel : NotificationObject
    {
        #region Members

        /// <summary>
        /// Region manager
        /// </summary>
        [Import]
        private IRegionManager RegionManager { get; set; }

        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        /// <summary>
        /// Username
        /// </summary>
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    RaisePropertyChanged(() => this.Username);
                }
            }
        }

        /// <summary>
        /// Password
        /// </summary>
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged(() => this.Password);
                }
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public AuthenticationViewModel()
        {
            // Register commands
            RegisterCommands();
        }

        #endregion

        #region Commands

        public ICommand Login { get; set; }

        /// <summary>
        /// Register Commands
        /// </summary>
        private void RegisterCommands()
        {
            Login = new DelegateCommand(OnLogin);
        }

        #endregion

        #region Events

        /// <summary>
        /// Check User Login
        /// </summary>
        private void OnLogin()
        {
            ModuleManager.LoadModule("DashboardModule");
            RegionManager.Regions[RegionNames.MainRegion].RequestNavigate(new Uri("Menu", UriKind.Relative));
        }

        #endregion
    }
}
