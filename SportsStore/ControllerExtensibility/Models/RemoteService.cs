using System.Threading;

namespace ControllerExtensibility.Models
{
    public class RemoteService
    {
        public string GetRemoteData()
        {
            Thread.Sleep(3000);
            return "Hello from the other side of the world!";
        }
    }
}