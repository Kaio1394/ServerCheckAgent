using System.ServiceProcess;

namespace ServerCheckAgent.Services.Interfaces
{
    public interface IServicesWindowsService
    {
        Task<IEnumerable<ServiceController>> GetServices();
        Task<(ServiceController?, string)> GetServiceByName(string serviceName);
        Task<(bool, string)> StartService(string serviceName);
        Task<(bool, string)> StopService(string serviceName);
    }
}
