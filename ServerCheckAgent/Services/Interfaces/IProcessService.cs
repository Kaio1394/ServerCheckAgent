namespace ServerCheckAgent.Services.Interfaces
{
    public interface IProcessService
    {
        Task<IEnumerable<Models.Process>> GetListProcess();
        Task<(bool, Models.Process)> KillProcessByPid(int pid);
        Task<Models.Process> GetProcessByPid(int pid);
    }
}
