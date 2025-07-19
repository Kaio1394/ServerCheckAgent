using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using ServerCheckAgent.Services.Interfaces;

namespace ServerCheckAgent.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessHelper _ProcessHelper; 
        public ProcessService(IProcessHelper ProcessHelpere)
        {
            _ProcessHelper = ProcessHelpere;
        }

        public Task<IEnumerable<Process>> GetListProcess()
        {
            return Task.Run(() =>
            {
                var listProcess = _ProcessHelper.GetListProcess();
                return listProcess;
            });
        }

        public Task<Process> GetProcessByPid(int pid)
        {
            return Task.Run(() =>
            {
                return _ProcessHelper.GetProcessByPid(pid);
            });
        }

        public Task<(bool, Process)> KillProcessByPid(int pid)
        {
            return Task.Run(() =>
            {
                return _ProcessHelper.KillProcessByPid(pid);
            });
        }
    }
}
