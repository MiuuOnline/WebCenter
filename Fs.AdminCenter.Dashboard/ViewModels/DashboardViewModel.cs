using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;

namespace Fs.AdminCenter.Dashboard.ViewModels
{
    [Export(typeof(DashboardViewModel))]
    public class DashboardViewModel : NotificationObject
    {

    }
}
