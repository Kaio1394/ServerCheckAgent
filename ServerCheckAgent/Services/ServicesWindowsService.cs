using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Services.Interfaces;
using System.ServiceProcess;

namespace ServerCheckAgent.Services
{
    public class ServicesWindowsService: IServicesWindowsService
    {
        private readonly IServicesWindowsHelper _helper;
        public ServicesWindowsService(IServicesWindowsHelper helper)
        {
            _helper = helper;
        }

        public Task<(ServiceController?, string)> GetServiceByName(string serviceName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ServiceController>> GetServices()
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string)> StartService(string serviceName)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string)> StopService(string serviceName)
        {
            throw new NotImplementedException();
        }
    }
}
