using ServerCheckAgent.Models;

namespace ServerCheckAgent.Helper.Interfaces
{
    public interface IHardwareInfoHelper
    {
        string GetProcessorName();
        uint GetCpuFrequency();
        float GetCpuUsage();
        int GetQtyCore();
        List<Disk> GetInfoDisk();
        Memory GetInfoMemory();
        Cpu GetInfoCpu();     
    }
}
