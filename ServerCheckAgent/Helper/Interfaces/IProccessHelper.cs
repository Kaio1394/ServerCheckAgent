namespace ServerCheckAgent.Helper.Interfaces
{
    public interface IProccessHelper
    {
        IEnumerable<Models.Process> GetListProcess();
        (bool, Models.Process) KillProcessByPid(int pid);
        Models.Process GetProcessByPid(int pid);
    }
}
