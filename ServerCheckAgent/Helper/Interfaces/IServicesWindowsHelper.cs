using System.ServiceProcess;

namespace ServerCheckAgent.Helper.Interfaces
{
    public interface IServicesWindowsHelper
    {
        IEnumerable<ServiceController> GetServices();
        (ServiceController?, string) GetServiceByName(string serviceName);
        (bool, string) StartService(string serviceName);
        (bool, string) StopService(string serviceName);
    }
}
