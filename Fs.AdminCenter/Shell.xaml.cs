using System;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using Fs.AdminCenter.Infrastructure.Events;
using Fs.AdminCenter.Logging;
using Fs.AdminCenter.ViewModels;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;

namespace Fs.AdminCenter
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    [Export(typeof(Shell))]
    public partial class Shell : Window, IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// Module manager
        /// </summary>
        [Import(AllowRecomposition = false)]
        private IModuleManager _moduleManager;

        /// <summary>
        /// Logger
        /// </summary>
        [Import(AllowRecomposition = false)]
        private CallbackLogger _logger;

        /// <summary>
        /// Event Agregator
        /// </summary>
        [Import]
        private IEventAggregator EventAggregator { get; set; }

        /// <summary>
        /// ViewModel import
        /// </summary>
        [Import]
        public ShellViewModel ViewModel
        {
            set { this.DataContext = value; }
        }


        /// <summary>
        /// ctor
        /// </summary>
        public Shell()
        {
            InitializeComponent();

            this.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                EventAggregator.GetEvent<GoToMenuViewEvent>().Publish("");
        }

        /// <summary>
        /// Fire when import satisfieds
        /// </summary>
        public void OnImportsSatisfied()
        {
            this._logger.Callback = this.Log;
            this._logger.ReplaySavedLogs();

            this._moduleManager.LoadModuleCompleted += OnLoadModuleCompleted;
            this._moduleManager.ModuleDownloadProgressChanged += OnModuleDownloadProgressChanged;

            this.EventAggregator.GetEvent<MainSwitchViewEvent>().Subscribe(ChangeDisplay);
            this.EventAggregator.GetEvent<GoToMenuViewEvent>().Subscribe(GoToMenuState);

        }

        /// <summary>
        /// Change Ui state when navigating
        /// </summary>
        /// <param name="obj"></param>
        private void ChangeDisplay(string obj)
        {
            ExtendedVisualStateManager.GoToElementState(LayoutRoot, "Navigation", true);
        }

        /// <summary>
        /// Get back to the main ui state
        /// </summary>
        /// <param name="obj"></param>
        private void GoToMenuState(string obj)
        {
            ExtendedVisualStateManager.GoToElementState(LayoutRoot, "Menu", true);
        }

        /// <summary>
        /// Fire when module progress changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnModuleDownloadProgressChanged(object sender, ModuleDownloadProgressChangedEventArgs e)
        {
            _logger.Log(e.ModuleInfo.ModuleName + " Loading : " + e.BytesReceived + " / " +  e.TotalBytesToReceive + "bytes.", Category.Debug, Priority.Low);
        }

        /// <summary>
        /// fire when a module get loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            _logger.Log(e.ModuleInfo.ModuleName + " loaded !", Category.Debug, Priority.Low);
        }

        /// <summary>
        /// Logging methods
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        /// <param name="priority"></param>
        public void Log(string message, Category category, Priority priority)
        {
            this.TraceTextBox.Text = string.Format(CultureInfo.CurrentUICulture,
                                    "{0} - [{1}][{2}] {3}\r\n",
                                    DateTime.Now.ToLongTimeString(),
                                    category,
                                    priority,
                                    message) + TraceTextBox.Text;
        }

    }
}
