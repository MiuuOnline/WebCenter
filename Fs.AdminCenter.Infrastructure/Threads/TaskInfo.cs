using System.Threading;

namespace Fs.AdminCenter.Infrastructure.Threads
{
    public class TaskInfo
    {
        public RegisteredWaitHandle Handle = null;
        public string OtherInfo = "default";
    }
}
