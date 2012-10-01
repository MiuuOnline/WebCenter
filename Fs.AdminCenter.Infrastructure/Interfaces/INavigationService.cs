using System.Collections.ObjectModel;
using Fs.AdminCenter.Infrastructure.Models;
using Fs.AdminCenter.Infrastructure.Models.Menu;

namespace Fs.AdminCenter.Infrastructure.Interfaces
{
    public interface INavigationService
    {
        ObservableCollection<MenuItem> MenuItems { get; set; }

        MenuItem GetItem(string name);

        void AddItem(MenuItem item);

        void AddItem(string name, string route);
    }
}
