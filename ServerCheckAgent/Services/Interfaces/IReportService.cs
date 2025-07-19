using ServerCheckAgent.Models;

namespace ServerCheckAgent.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportServer> GenerateReportServer();
    }
}
