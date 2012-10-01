using System.ComponentModel.Composition;
using Fs.AdminCenter.Infrastructure.Modules;
using Fs.AdminCenter.Infrastructure.Region;
using Fs.AdminCenter.Navigation.Views;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Fs.AdminCenter.Navigation
{
    [ModuleExport(ModuleNames.NavigationModule, typeof(NavigationModule), InitializationMode = InitializationMode.OnDemand)]
    public class NavigationModule : IModule, IPartImportsSatisfiedNotification
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
        /// Init
        /// </summary>
        public void Initialize()
        {
            this.RegionManager.RegisterViewWithRegion(RegionNames.MainMenuRegion, typeof(MainMenu));
            this.RegionManager.RegisterViewWithRegion(RegionNames.ContextSelectionRegion, typeof(ContextSelectionView));
        }

        /// <summary>
        /// Fire when import are satisfied
        /// </summary>
        public void OnImportsSatisfied()
        {
           
        }
    }
}
