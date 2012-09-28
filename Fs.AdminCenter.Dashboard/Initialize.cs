using System.ComponentModel.Composition;
using Fs.AdminCenter.Dashboard.Views;
using Fs.AdminCenter.Infrastructure.Region;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Fs.AdminCenter.Dashboard
{
    [ModuleExport("DashboardModule", typeof(DashboardModule), InitializationMode = InitializationMode.OnDemand)]
    public class DashboardModule : IModule
    {
        /// <summary>
        /// Region manager
        /// </summary>
        [Import]
        private IRegionManager RegionManager { get; set; }

        /// <summary>
        /// Init
        /// </summary>
        public void Initialize()
        {
            this.RegionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Menu));
        }
    }
}
