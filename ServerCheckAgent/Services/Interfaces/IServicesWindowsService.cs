using ServerCheckAgent.Models;
using System.ServiceProcess;

namespace ServerCheckAgent.Services.Interfaces
{
    public interface IServicesWindowsService
    {
        Task<IEnumerable<Service>> GetServices();
        //Task<(ServiceController?, string)> GetServiceByName(string serviceName);
        Task<bool> StartService(string serviceName);
        Task<bool> StopService(string serviceName);
        Task<bool> ServiceExist(string serviceName);
    }
}
