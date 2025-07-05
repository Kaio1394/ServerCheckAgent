using ServerCheckAgent.Controllers;
using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using System.Diagnostics.CodeAnalysis;
using System.ServiceProcess;

namespace ServerCheckAgent.Helper
{
    [ExcludeFromCodeCoverage]
    public class ServicesWindowsHelper: IServicesWindowsHelper
    {
        private static IEnumerable<Service> _listServices;
        public IEnumerable<Service> GetServices()
        {
            try
            {
                _listServices = ServiceController.GetServices()
                                                 .Select(s => new Service
                                                 {
                                                     ServiceName = s.ServiceName,
                                                     Status = s.Status.ToString(),
                                                     DisplayName = s.DisplayName
                                                 })
                                                 .ToList();

                return _listServices; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ServiceController GetServiceByName(string serviceName)
        {
            try
            {
                var service = ServiceController.GetServices()
                    .FirstOrDefault(s => s.ServiceName.Equals(serviceName, StringComparison.OrdinalIgnoreCase));

                return service;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool StartService(string serviceName)
        {
            try
            {
                var service = GetServiceByName(serviceName);

                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                }
                return true;
            }
            catch (Exception)
            {
               throw;
            }
        }

        public bool StopService(string serviceName)
        {
            try
            {
                var service = GetServiceByName(serviceName);

                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ServiceExists(string serviceName)
        {
            try
            {
                return ServiceController.GetServices()
                            .Any(s => s.ServiceName.Equals(serviceName, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
