using System.Collections.Generic;
using System.ComponentModel.Composition;
using Fs.AdminCenter.Infrastructure.Interfaces;
using Fs.AdminCenter.Infrastructure.Models.Menu;
using Fs.AdminCenter.Infrastructure.Modules;
using Fs.AdminCenter.Infrastructure.Pages;
using Fs.AdminCenter.Infrastructure.Region;
using Fs.AdminCenter.Warehouse.Views;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Fs.AdminCenter.Warehouse
{
    [ModuleExport(ModuleNames.WarehouseModule, typeof(WarehouseModule), InitializationMode = InitializationMode.OnDemand)]
    public class WarehouseModule : IModule, IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// Region manager
        /// </summary>
        [Import]
        private IRegionManager RegionManager { get; set; }
        
        /// <summary>
        /// Logger
        /// </summary>
        [Import(AllowRecomposition = false)]
        private ILoggerFacade _logger;

        /// <summary>
        /// Menu Service
        /// </summary>
        [Import]
        public INavigationService NavigationService { get; set; }

        /// <summary>
        /// Init
        /// </summary>
        public void Initialize()
        {
            RegisterMenuRoutes();

            this.RegionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(ProductList));
        }

        private void RegisterMenuRoutes()
        {
            NavigationService.AddItem(new MenuItem()
            {
                Name = "Warehouse",
                Route = PageNames.ProductListView,
                MenuSubItems = new List<MenuSubItem>()
            });
        }

        /// <summary>
        /// Fire when import are satisfied
        /// </summary>
        public void OnImportsSatisfied()
        {
            
        }
    }
}
