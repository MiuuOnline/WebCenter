using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fs.AdminCenter.Infrastructure.AdminServiceReference;
using Fs.AdminCenter.Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;

namespace Fs.AdminCenter.Warehouse.ViewModels
{
    [Export]
    public class ProductViewModel : NotificationObject, IPartImportsSatisfiedNotification, INavigationAware
    {

        /// <summary>
        /// Context service
        /// </summary>
        [Import]
        public IContextService ContextService { get; set; }

        /// <summary>
        /// Product collection
        /// </summary>
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                RaisePropertyChanged(() => this.Products);
            }
        }

        public ProductViewModel()
        {
            //Products = new ObservableCollection<Product>();
        }

        public void OnImportsSatisfied()
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Products = new ObservableCollection<Product>(ContextService.Context.Products.ToList());
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Products = null;
        }
    }
}
