using ServerCheckAgent.Helper.Interfaces;

namespace ServerCheckAgent.Helper
{
    public class ProccessHelper: IProccessHelper
    {
        public Models.Process GetProcessByPid(int pid)
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();

            try
            {
                foreach (System.Diagnostics.Process process in processes)
                {
                    if (process.Id == pid)
                    {
                        long memoryMB = process.WorkingSet64 / (1024 * 1024);

                        var processModel = new Models.Process
                        {
                            Id = process.Id,
                            Name = process.ProcessName,
                            UsageMemoryAux = memoryMB,
                            UsageMemory = $"{memoryMB} MB"
                        };
                        return processModel;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public (bool, Models.Process) KillProcessByPid(int pid)
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
            try
            {
                foreach (System.Diagnostics.Process process in processes)
                {
                    if (process.Id == pid)
                    {
                        long memoryMB = process.WorkingSet64 / (1024 * 1024);

                        var processModel = new Models.Process
                        {
                            Id = process.Id,
                            Name = process.ProcessName,
                            UsageMemoryAux = memoryMB,
                            UsageMemory = $"{memoryMB} MB"
                        };

                        process.Kill();
                        process.WaitForExitAsync();

                        return (true, processModel);
                    }
                }
                return (false, null);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Models.Process> GetListProcess()
        {
            var listProcess = new List<Models.Process>();

            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();

            foreach (System.Diagnostics.Process process in processes)
            {
                try
                {
                    long memoryMB = process.WorkingSet64 / (1024 * 1024);

                    if (memoryMB > 0)
                        listProcess.Add(new Models.Process
                        {
                            Id = process.Id,
                            Name = process.ProcessName,
                            UsageMemoryAux = memoryMB,
                            UsageMemory = $"{memoryMB} MB"
                        });
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return listProcess.OrderByDescending(x => x.UsageMemoryAux).ToList();
        }
    }
}
