using Hardware.Info;
using ServerCheckAgent.Helper;
using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using ServerCheckAgent.Services.Interfaces;

namespace ServerCheckAgent.Services
{
    public class ReportService : IReportService
    {
        private readonly IHardwareInfoHelper _hardwareInfo;
        private readonly IEventViewerHelper _eventViewerHelper;
        private readonly IProcessHelper _processHelper;
        private readonly IServicesWindowsHelper _servicesWindowsHelper;
        public ReportService(IHardwareInfoHelper hardwareInfo, IEventViewerHelper eventViewerHelper, IProcessHelper processHelper, IServicesWindowsHelper servicesWindowsHelper)
        {
            _hardwareInfo = hardwareInfo;
            _eventViewerHelper = eventViewerHelper;
            _processHelper = processHelper;
            _servicesWindowsHelper = servicesWindowsHelper;
        }

        public Task<ReportServer> GenerateReportServer()
        {
            return Task.Run(() =>
            {
                var cpuInfo = _hardwareInfo.GetInfoCpu();
                var memoryInfo = _hardwareInfo?.GetInfoMemory();
                var diskInfo = _hardwareInfo?.GetInfoDisk();
                //var listEventViewer = _eventViewerHelper.GetEventViewList("Application", "Information", DateTime.Now.ToString("yyyy-MM-dd"), "*");
                var listServices = _servicesWindowsHelper.GetServices();
                var listProcess = _processHelper.GetListProcess();

                var reportServer = new ReportServer
                {
                    Cpu = cpuInfo,
                    Memory = memoryInfo,
                    ListDisk = diskInfo,
                    Process = listProcess,
                    Services = listServices
                };
                return reportServer;
            });
        }
    }
}
