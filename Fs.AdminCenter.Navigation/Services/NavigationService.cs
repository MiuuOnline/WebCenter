using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Fs.AdminCenter.Infrastructure.Interfaces;
using Fs.AdminCenter.Infrastructure.Models.Menu;
using Microsoft.Practices.Prism.ViewModel;

namespace Fs.AdminCenter.Navigation.Services
{
    [Export(typeof(INavigationService))]
    public class NavigationService : NotificationObject, INavigationService
    {
        private ObservableCollection<MenuItem> _menuItems;

        public NavigationService()
        {
            _menuItems = new ObservableCollection<MenuItem>();
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                RaisePropertyChanged(() => MenuItems);
            }
        }

        public MenuItem GetItem(string name)
        {
            return _menuItems.FirstOrDefault(i => i.Name == name);
        }

        public void AddItem(MenuItem item)
        {
            MenuItems.Add(item);
        }

        public void AddItem(string name, string route)
        {
            _menuItems.Add(new MenuItem
            {
                Name = name,
                Route = route
            });
        }
    }
}
