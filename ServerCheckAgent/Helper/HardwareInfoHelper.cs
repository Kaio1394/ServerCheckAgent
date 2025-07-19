using Hardware.Info;
using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using System.Diagnostics;
using System.Management;

namespace ServerCheckAgent.Helper
{
    public class HardwareInfoHelper : IHardwareInfoHelper
    {
        private readonly IHardwareInfo _hardwareInfo;

        public HardwareInfoHelper(IHardwareInfo hardwareInfo)
        {
            _hardwareInfo = hardwareInfo;
        }
        public int GetQtyCore()
        {
            return Environment.ProcessorCount;
        }
        public uint GetCpuFrequency()
        {
            try
            {
                _hardwareInfo.RefreshCPUList();

                var cpu = _hardwareInfo.CpuList.FirstOrDefault();
                return cpu.MaxClockSpeed;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetProcessorName()
        {
            string cpuName = "Desconhecido";
            try
            {
                using var searcher = new ManagementObjectSearcher("select Name from Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    cpuName = obj["Name"]?.ToString() ?? "Desconhecido";
                    break;
                }
                return cpuName.Trim();
            }
            catch
            {
                return "Desconhecido";
            }
        }

        public float GetCpuUsage()
        {
            try
            {
                using var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                _ = cpuCounter.NextValue();

                System.Threading.Thread.Sleep(1000);

                float cpuUsage = cpuCounter.NextValue();
                return cpuUsage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cpu GetInfoCpu()
        {
            return new Cpu()
            {
                NameProcessor = GetProcessorName(),
                Core = GetQtyCore(),
                Frequency = GetCpuFrequency(),
                UsagePercent = GetCpuUsage(),
            };
        }

        public List<Disk> GetInfoDisk()
        {
            List<Disk> list = new List<Disk>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    long totalSpace = drive.TotalSize / (1024 * 1024 * 1024);
                    long freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                    long usedSpace = totalSpace - freeSpace;

                    list.Add(new Disk()
                    {
                        Name = drive.Name,
                        Info = new DictionaryInfoDisk()
                        {
                            TotalSpace = totalSpace,
                            UsedSpace = usedSpace,
                            FreeSpace = freeSpace,
                        }
                    });
                }
            }
            return list;
        }

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
