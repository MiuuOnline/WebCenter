using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Fs.AdminCenter.Infrastructure.Events;
using Fs.AdminCenter.Infrastructure.Interfaces;
using Fs.AdminCenter.Infrastructure.Models.Menu;
using Fs.AdminCenter.Infrastructure.Region;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;

namespace Fs.AdminCenter.Navigation.ViewModels
{
    /// <summary>
    /// Responsible for the Main Menu representation of the application
    /// </summary>
    [Export]
    public class NavigationViewModel : NotificationObject, IPartImportsSatisfiedNotification
    {

        #region Members

        [Import]
        private IEventAggregator EventAggregator { get; set; }

        [Import]
        public INavigationService NavigationService { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        private MenuSubItem _selectedNavigationMenuItem;
        public MenuSubItem SelectedNavigationMenuItem
        {
            get { return _selectedNavigationMenuItem; }
            set
            {
                _selectedNavigationMenuItem = value;
                RaisePropertyChanged(() => SelectedNavigationMenuItem);
                if (value != null)
                    OnMoveToNagivationView(SelectedNavigationMenuItem.Route);
            }
        }

        private MenuItem _selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                RaisePropertyChanged(() => SelectedMenuItem);
                if (value != null)
                    OnMoveToNagivationView(SelectedMenuItem.Route);
            }
        }

        public ObservableCollection<MenuItem> MenuItems { get; set; }

        #endregion

        #region Ctor

        public NavigationViewModel()
        {
            RegisterCommands();

            Initialize();
        }

        private void Initialize()
        {
            MenuItems = new ObservableCollection<MenuItem>();


        }

        public void OnImportsSatisfied()
        {
            EventAggregator.GetEvent<MainSwitchViewEvent>().Subscribe(OnSwitchViewEvent, ThreadOption.UIThread, true);
            EventAggregator.GetEvent<GoToMenuViewEvent>().Subscribe(OnResetMenu);

        }

        #endregion

        #region Commands

        public ICommand GoToMainMenu { get; set; }

        private void RegisterCommands()
        {
            GoToMainMenu = new DelegateCommand(OnMoveToGoToMainMenu);
        }

        #endregion

        #region Methods

        private void OnResetMenu(string obj)
        {
            SelectedMenuItem = null;
            SelectedNavigationMenuItem = null;
        }

        private void OnSwitchViewEvent(string viewName)
        {
            DisplayView(viewName);
        }

        private void OnMoveToGoToMainMenu()
        {
            //_eventAggregator.GetEvent<GoToMenuViewEvent>().Publish("");
        }

        private void OnMoveToNagivationView(string route)
        {
            EventAggregator.GetEvent<MainSwitchViewEvent>().Publish(route);
        }

        #endregion



        private void DisplayView(string viewName)
        {
            RegionManager.RequestNavigate(RegionNames.MainRegion, new Uri("/" + viewName, UriKind.Relative));
        }
    }
}
