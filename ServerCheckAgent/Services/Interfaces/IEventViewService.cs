using ServerCheckAgent.Models;

namespace ServerCheckAgent.Services.Interfaces
{
    public interface IEventViewService
    {
        Task<IEnumerable<EventView>> GetEventViewList(string entryType, string logName, string date, string limit);
    }
}
