using Microsoft.Practices.Prism.Events;

namespace Fs.AdminCenter.Infrastructure.Events
{
    public class MainSwitchViewEvent : CompositePresentationEvent<string>
    {
    }


    public class GoToMenuViewEvent : CompositePresentationEvent<string>
    {
    }

    public class GoToLoginViewEvent : CompositePresentationEvent<string>
    {
    }
}
