using System;
using System.ComponentModel.Composition;
using System.Threading;
using Fs.AdminCenter.Infrastructure.Threads;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace Fs.AdminCenter.ViewModels
{
    [Export]
    public class ShellViewModel : NotificationObject
    {

        #region Members

        /// <summary>
        /// Current DataTime
        /// </summary>
        private DateTime _currentTime;

        public DateTime CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                RaisePropertyChanged(() => CurrentTime);
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public ShellViewModel()
        {
            Initialize();

            RegisterCommands();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void Initialize()
        {
            // Thread the clock
            var ti = new TaskInfo();
            AutoResetEvent ev = new AutoResetEvent(false);
            ti.Handle = ThreadPool.RegisterWaitForSingleObject(ev, WaitClockProc, ti, 1000, false);
        }

        /// <summary>
        /// Handle thread for the clock
        /// </summary>
        /// <param name="state"></param>
        /// <param name="timedout"></param>
        private void WaitClockProc(object state, bool timedout)
        {
            CurrentTime = DateTime.Now;
        }

        #endregion

        #region Commands

        /// <summary>
        /// Exit Cmd
        /// </summary>
        public DelegateCommand<object> ExitCommand { get; private set; }

        /// <summary>
        /// Initialize commands
        /// </summary>
        private void RegisterCommands()
        {
            ExitCommand = new DelegateCommand<object>(AppExit, CanAppExit);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Exit methods
        /// </summary>
        /// <param name="commandArg"></param>
        private void AppExit(object commandArg)
        {
            App.Current.Shutdown();
        }

        /// <summary>
        /// Can exit flag if needed
        /// </summary>
        /// <param name="commandArg"></param>
        /// <returns></returns>
        private bool CanAppExit(object commandArg)
        {
            return true;
        }

        #endregion
    }
}
