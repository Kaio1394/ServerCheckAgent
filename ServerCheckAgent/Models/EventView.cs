using System.Diagnostics.CodeAnalysis;

namespace ServerCheckAgent.Models
{
    [ExcludeFromCodeCoverage]
    public class EventView
    {
        public required string? EntryType { get; set; }
        public required string? Source { get; set; }
        public required string? Message { get; set; }
        public required string? TimeGenerated { get; set; }
    }
}
