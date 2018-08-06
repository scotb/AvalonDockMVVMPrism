using AvalonDockMVVMPrism.Views;
using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace AvalonDockMVVMPrism
{
    ///<summary>
    ///     Bootstrapper for the Avalon Dock MVVM Prism Application.
    /// </summary>
    /// <Remarks>
    ///
    ///     These are the ordered steps the bootstrapper performs as part of it's setup.
    ///
    ///     1. Create the logger
    ///     this.Logger = this.CreateLogger();
    ///     2. Create the module catalog
    ///     this.ModuleCatalog = this.CreateModuleCatalog();
    ///     3. Configure the module catalog
    ///     this.ConfigureModuleCatalog();
    ///     4. Create the container
    ///     this.Container = this.CreateContainer();
    ///     5. Configure the container
    ///     this.ConfigureContainer();
    ///     6. Configure the service locator
    ///     this.ConfigureServiceLocator();
    ///     7. Configure region adapter mappings
    ///     this.ConfigureRegionAdapterMappings();
    ///     8. Configure default region behaviors
    ///     this.ConfigureDefaultRegionBehaviors();
    ///     9. Register the framework exception types
    ///     this.RegisterFrameworkExceptionTypes();
    ///     10. Create the shell
    ///     this.Shell = this.CreateShell();
    ///     11. Set the region manager
    ///     RegionManager.SetRegionManager(this.Shell, this.Container.Resolve<IRegionManager>());
    ///     12. Update the regions
    ///     RegionManager.UpdateRegions();
    ///     13. Initialize the shell
    ///     this.InitializeShell();
    ///     14. Initialize the modules
    ///     this.InitializeModules();
    ///
    /// </Remarks>
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            //moduleCatalog.AddModule(typeof(YOUR_MODULE));
        }
    }
}