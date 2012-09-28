using System.ComponentModel.Composition;
using Fs.AdminCenter.Authentication.Views;
using Fs.AdminCenter.Infrastructure.Region;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Fs.AdminCenter.Authentication
{
    /// <summary>
    /// Entry point of the Authentication Module
    /// </summary>
    [ModuleExport(typeof(AuthenticationModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class AuthenticationModule : IModule
    {
        /// <summary>
        /// Region manager
        /// </summary>
        private IRegionManager RegionManager { get; set; }

        /// <summary>
        /// Init
        /// </summary>
        public void Initialize()
        {
            this.RegionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Login));

        }
    }
}
