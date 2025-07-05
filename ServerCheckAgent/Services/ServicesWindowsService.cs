using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
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

        public Task<IEnumerable<Service>> GetServices()
        {
            return Task.Run(() => _helper.GetServices());
        }

        public Task<bool> ServiceExist(string serviceName)
        {
            return Task.Run(()=> _helper.ServiceExists(serviceName));
        }

        public Task<bool> StartService(string serviceName)
        {
            return Task.Run(() => _helper.StartService(serviceName));
        }

        public Task<bool> StopService(string serviceName)
        {
            return Task.Run(() => _helper.StopService(serviceName));
        }
    }
}
