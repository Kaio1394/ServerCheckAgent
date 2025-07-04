using ServerCheckAgent.Controllers;
using ServerCheckAgent.Helper.Interfaces;
using System.ServiceProcess;

namespace ServerCheckAgent.Helper
{
    public class ServicesWindowsHelper: IServicesWindowsHelper
    {
        public IEnumerable<ServiceController> GetServices()
        {
            try
            {
                return ServiceController.GetServices().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public (ServiceController?, string) GetServiceByName(string serviceName)
        {
            try
            {
                return (ServiceController.GetServices()
                    .FirstOrDefault(s => s.ServiceName.Equals(serviceName, StringComparison.OrdinalIgnoreCase)), "");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public (bool, string) StartService(string serviceName)
        {
            try
            {
                var service = GetServiceByName(serviceName);

                if (service.Item1.Status == ServiceControllerStatus.Stopped)
                {
                    service.Item1.Start();
                    service.Item1.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                }
                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) StopService(string serviceName)
        {
            try
            {
                var service = GetServiceByName(serviceName);

                if (service.Item1.Status == ServiceControllerStatus.Running)
                {
                    service.Item1.Stop();
                    service.Item1.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                }
                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
