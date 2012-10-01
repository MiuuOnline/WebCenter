using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Fs.AdminCenter.Infrastructure.Interfaces;
using Fs.AdminCenter.Infrastructure.Modules;
using Fs.AdminCenter.Infrastructure.Pages;
using Fs.AdminCenter.Infrastructure.Region;
using Microsoft.Practices.Prism.Commands;
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

        /// <summary>
        /// Module Manager
        /// </summary>
        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager { get; set; }

        /// <summary>
        /// Context Service
        /// </summary>
        [Import]
        private IContextService ContextService { get; set; }

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

        public ICommand Logout { get; set; }

        /// <summary>
        /// Register Commands
        /// </summary>
        private void RegisterCommands()
        {
            Login = new DelegateCommand(OnLogin);
            Logout = new DelegateCommand(OnLogout);
        }

        #endregion

        #region Events

        /// <summary>
        /// Check User Login
        /// </summary>
        private void OnLogin()
        {
            // Get Auth

            // Load Context
            ContextService.AddContext("Dev 1", "http://localhost/dev/AdminService.svc");
            ContextService.AddContext("Dev 2", "http://localhost/dev2/AdminService.svc");

            // Select default context
            ContextService.SelecteDefaultContext("Dev 1");

            // Load Module
            ModuleManager.LoadModule(ModuleNames.NavigationModule);
            ModuleManager.LoadModule(ModuleNames.DashboardModule);
            ModuleManager.LoadModule(ModuleNames.WarehouseModule);

            // Navigate to uri
            RegionManager.Regions[RegionNames.MainMenuRegion].RequestNavigate(new Uri(PageNames.MainMenuView, UriKind.Relative));
        }

        /// <summary>
        /// Logout methods
        /// </summary>
        private void OnLogout()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
