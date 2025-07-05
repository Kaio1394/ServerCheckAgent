using ServerCheckAgent.Models;
using System.ServiceProcess;

namespace ServerCheckAgent.Helper.Interfaces
{
    public interface IServicesWindowsHelper
    {
        IEnumerable<Service> GetServices();
        ServiceController GetServiceByName(string serviceName);
        bool StartService(string serviceName);
        bool StopService(string serviceName);
        bool ServiceExists(string serviceName);
    }
}
