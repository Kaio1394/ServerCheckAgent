using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using ServerCheckAgent.Services.Interfaces;

namespace ServerCheckAgent.Services
{
    public class EventViewService : IEventViewService
    {
        private readonly IEventViewerHelper _eventViewerHelper;
        public EventViewService(IEventViewerHelper eventViewerHelper)
        {
            _eventViewerHelper = eventViewerHelper;
        }
        public Task<IEnumerable<EventView>> GetEventViewList(string logName, string date, string limit)
        {
            return Task.Run(() =>
            {
                return _eventViewerHelper.GetEventViewList(logName, date, limit);
            });
        }
    }
}
