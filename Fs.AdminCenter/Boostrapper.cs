using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Fs.AdminCenter.Authentication;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;

namespace Fs.AdminCenter
{
    /// <summary>
    /// Bootstrapper of the application
    /// </summary>
    public class Boostrapper : MefBootstrapper
    {
        /// <summary>
        /// Get the application shell
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            // Get the shell from the container
            return this.Container.GetExportedValue<Shell>();
        }

        /// <summary>
        /// Get the module catalog
        /// </summary>
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
             
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Boostrapper).Assembly));

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AuthenticationModule).Assembly));
        }

        /// <summary>
        /// Module Initialization
        /// </summary>
        protected override void InitializeModules()
        {
            base.InitializeModules();            
        }

        /// <summary>
        /// Create the module catalog
        /// </summary>
        /// <returns></returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        /// <summary>
        /// Configure the main container
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        /// <summary>
        /// Create the main container
        /// </summary>
        /// <returns></returns>
        protected override CompositionContainer CreateContainer()
        {
            var localContainer = base.CreateContainer();

            return localContainer;
        }

        /// <summary>
        /// Sheel initialization and startup
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell)Shell;
            Application.Current.MainWindow.Show();
        }
    }
}
