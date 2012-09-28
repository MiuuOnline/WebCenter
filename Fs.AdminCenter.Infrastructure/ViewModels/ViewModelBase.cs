using Microsoft.Practices.Prism.ViewModel;

namespace Fs.AdminCenter.Infrastructure.ViewModels
{
    public abstract class ViewModelBase : NotificationObject
    {

        protected ViewModelBase()
        {
            this.RegisterCommands();
        }

        protected void RegisterCommands()
        {
            
        }

    }
}
