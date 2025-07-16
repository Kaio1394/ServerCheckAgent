namespace ServerCheckAgent.Models
{
    public class Memory
    {
        public decimal Total { get; internal set; }
        public decimal Free { get; internal set; }
        public decimal Usage { get; internal set; }
    }
}