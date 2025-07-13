namespace ServerCheckAgent.Helper.Interfaces
{
    public interface IProcessHelper
    {
        IEnumerable<Models.Process> GetListProcess();
        (bool, Models.Process) KillProcessByPid(int pid);
        Models.Process GetProcessByPid(int pid);
    }
}
