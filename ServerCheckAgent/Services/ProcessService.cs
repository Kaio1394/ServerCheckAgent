using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using ServerCheckAgent.Services.Interfaces;

namespace ServerCheckAgent.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessHelper _ProcessHelpere; 
        public ProcessService(IProcessHelper ProcessHelpere)
        {
            _ProcessHelpere = ProcessHelpere;
        }

        public Task<IEnumerable<Process>> GetListProcess()
        {
            return Task.Run(() =>
            {
                var listProcess = _ProcessHelpere.GetListProcess();
                return listProcess;
            });
        }

        public Task<Process> GetProcessByPid(int pid)
        {
            return Task.Run(() =>
            {
                return _ProcessHelpere.GetProcessByPid(pid);
            });
        }

        public Task<(bool, Process)> KillProcessByPid(int pid)
        {
            return Task.Run(() =>
            {
                return _ProcessHelpere.KillProcessByPid(pid);
            });
        }
    }
}
