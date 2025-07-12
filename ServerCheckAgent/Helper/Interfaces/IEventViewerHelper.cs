using ServerCheckAgent.Models;

namespace ServerCheckAgent.Helper.Interfaces
{
    public interface IEventViewerHelper
    {
        IEnumerable<EventView> GetEventViewList(string logName, string date, string lastTime);
    }
}
