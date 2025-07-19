namespace ServerCheckAgent.Models
{
    public class ReportServer
    {
        public Models.Memory? Memory { get; set; }
        public Models.Cpu? Cpu { get; set; }
        public IEnumerable<Models.Disk> ListDisk { get; set; } = new List<Models.Disk>();
        public IEnumerable<Models.Process> Process { get; set; } = new List<Models.Process>();
        public IEnumerable<Models.Service> Services { get; set; } = new List<Models.Service>();
        public IEnumerable<Models.EventView> EventViewer { get; set; } = new List<Models.EventView>();
    }
}
