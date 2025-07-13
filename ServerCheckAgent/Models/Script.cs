namespace ServerCheckAgent.Models
{
    public class Script
    {
        public string? Code { get; set; }
        public int? TimeoutSeconds { get; set; } = 60;
    }
}
