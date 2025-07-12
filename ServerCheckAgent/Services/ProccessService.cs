using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using ServerCheckAgent.Services.Interfaces;

namespace ServerCheckAgent.Services
{
    public class ProccessService : IProccessService
    {
        private readonly IProccessHelper _proccessHelpere; 
        public ProccessService(IProccessHelper proccessHelpere)
        {
            _proccessHelpere = proccessHelpere;
        }

        public Task<IEnumerable<Process>> GetListProcess()
        {
            return Task.Run(() =>
            {
                var listProccess = _proccessHelpere.GetListProcess();
                return listProccess;
            });
        }

        public Task<Process> GetProcessByPid(int pid)
        {
            return Task.Run(() =>
            {
                return _proccessHelpere.GetProcessByPid(pid);
            });
        }

        public Task<(bool, Process)> KillProcessByPid(int pid)
        {
            return Task.Run(() =>
            {
                return _proccessHelpere.KillProcessByPid(pid);
            });
        }
    }
}
