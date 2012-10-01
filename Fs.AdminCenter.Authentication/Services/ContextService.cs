using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Fs.AdminCenter.Infrastructure.AdminServiceReference;
using Fs.AdminCenter.Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.ViewModel;

namespace Fs.AdminCenter.Authentication.Services
{
    [Export(typeof(IContextService))]
    public class ContextService : NotificationObject, IContextService 
    {
        /// <summary>
        /// Logger
        /// </summary>
        [Import(AllowRecomposition = false)]
        private ILoggerFacade _logger;


        /// <summary>
        /// Main Dictionary which contains the contexts
        /// </summary>
        private Dictionary<string, FsContext> _contexts = new Dictionary<string, FsContext>();

        /// <summary>
        /// Current Context
        /// </summary>
        public FsContext Context
        {
            get
            {
                if (SelectedContext == null)
                    SelectedContext = ContextNames.First();   
                return _contexts[SelectedContext];
            }
        }

        /// <summary>
        /// Context collection
        /// </summary>
        private ObservableCollection<string> _contextNames;
        public ObservableCollection<string> ContextNames
        {
            get { return _contextNames; }
            set
            {
                _contextNames = value;
                RaisePropertyChanged(() => this.ContextNames);
            }
        }

        /// <summary>
        /// Selected context
        /// </summary>
        private string _selectedContext;
        public string SelectedContext
        {
            get { return _selectedContext; }
            set
            {
                _selectedContext = value;
                RaisePropertyChanged(() => this.SelectedContext);
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        public ContextService()
        {
            Initialize();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Initialize()
        {
            ContextNames = new ObservableCollection<string>();
        }

        /// <summary>
        /// Add a context
        /// </summary>
        /// <param name="name"></param>
        /// <param name="uri"></param>
        public void AddContext(string name, string uri)
        {
            // add to name table
            ContextNames.Add(name);

            // add the context
            _contexts.Add(name, new FsContext(new Uri(uri)));

            // log
            _logger.Log("Context -- > " + name + " Loaded !", Category.Info, Priority.Medium);
        }

        /// <summary>
        /// Set the default context
        /// </summary>
        /// <param name="name"></param>
        public void SelecteDefaultContext(string name)
        {
            SelectedContext = name;
        }

        /// <summary>
        /// Save the current context
        /// </summary>
        public void SaveContext()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.Log("Fail !", Category.Exception, Priority.High);
                
                throw;
            }
            
        }
    }
}
