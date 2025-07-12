namespace ServerCheckAgent.Services.Interfaces
{
    public interface IProccessService
    {
        Task<IEnumerable<Models.Process>> GetListProcess();
        Task<(bool, Models.Process)> KillProcessByPid(int pid);
        Task<Models.Process> GetProcessByPid(int pid);
    }
}
