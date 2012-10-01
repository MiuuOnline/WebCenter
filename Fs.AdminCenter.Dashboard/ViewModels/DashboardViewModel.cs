using System;
using System.ComponentModel.Composition;
using System.Data.Services.Client;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using Microsoft.Practices.Prism.ViewModel;

namespace Fs.AdminCenter.Dashboard.ViewModels
{
    [Export(typeof(DashboardViewModel))]
    public class DashboardViewModel : NotificationObject
    {
        public DashboardViewModel()
        {

        }

    }
}
