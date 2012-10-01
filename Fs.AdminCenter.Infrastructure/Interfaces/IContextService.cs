using System.Collections.ObjectModel;
using Fs.AdminCenter.Infrastructure.AdminServiceReference;

namespace Fs.AdminCenter.Infrastructure.Interfaces
{
    /// <summary>
    /// Context service
    /// </summary>
    public interface IContextService
    {
        /// <summary>
        /// Context list
        /// </summary>
        ObservableCollection<string> ContextNames { get; set; }

        /// <summary>
        /// Current Context
        /// </summary>
        FsContext Context { get; }

        /// <summary>
        /// Add a context
        /// </summary>
        /// <param name="name"></param>
        /// <param name="uri"></param>
        void AddContext(string name, string uri);

        /// <summary>
        /// Set the default context
        /// </summary>
        void SelecteDefaultContext(string name);

        /// <summary>
        /// Save the current context
        /// </summary>
        void SaveContext();
    }
}
