using System.Collections.Generic;
using System.ComponentModel.Composition;
using Fs.AdminCenter.Dashboard.Views;
using Fs.AdminCenter.Infrastructure.Interfaces;
using Fs.AdminCenter.Infrastructure.Models.Menu;
using Fs.AdminCenter.Infrastructure.Modules;
using Fs.AdminCenter.Infrastructure.Pages;
using Fs.AdminCenter.Infrastructure.Region;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Fs.AdminCenter.Dashboard
{
    [ModuleExport(ModuleNames.DashboardModule, typeof(DashboardModule), InitializationMode = InitializationMode.OnDemand)]
    public class DashboardModule : IModule, IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// Region manager
        /// </summary>
        [Import]
        private IRegionManager RegionManager { get; set; }

        /// <summary>
        /// Menu Service
        /// </summary>
        [Import]
        public INavigationService MenuService { get; set; }
        
        /// <summary>
        /// Logger
        /// </summary>
        [Import]
        private ILoggerFacade LoggerFacade { get; set; }

        /// <summary>
        /// Init
        /// </summary>
        public void Initialize()
        {
            // Register Menu entries and routes
            RegisterMenuRoutes();

            // Register Pages with regions
            this.RegionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(DashboardMainView));
        }

        /// <summary>
        /// Register main view route
        /// </summary>
        private void RegisterMenuRoutes()
        {
            MenuService.AddItem(new MenuItem()
                {
                    Name = "Dashboard",
                    Route = PageNames.DashboardMainView,
                    MenuSubItems = new List<MenuSubItem>()
                });
        }

        /// <summary>
        /// Fire when imports are satisfied
        /// </summary>
        public void OnImportsSatisfied()
        {
            
        }
    }
}
