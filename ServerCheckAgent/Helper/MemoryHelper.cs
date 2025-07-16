using ServerCheckAgent.Helper.Interfaces;
using System.Management;

namespace ServerCheckAgent.Helper
{
    public class MemoryHelper: IMemoryHelper
    {
        public Models.Memory GetInfoMemory()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            Models.Memory? memory = new Models.Memory();
            foreach (var obj in searcher.Get())
            {
                double totalVisibleMemory = Convert.ToDouble(obj["TotalVisibleMemorySize"]) / 1024;
                double freePhysicalMemory = Convert.ToDouble(obj["FreePhysicalMemory"]) / 1024;
                double usedMemory = totalVisibleMemory - freePhysicalMemory;

                memory.Total = Convert.ToDecimal($"{totalVisibleMemory:F2}");
                memory.Free = Convert.ToDecimal($"{freePhysicalMemory:F2}");
                memory.Usage = Convert.ToDecimal($"{usedMemory:F2}");
            }
            return memory;
        }
    }
}
