using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ServerCheckAgent.Helper
{
    [ExcludeFromCodeCoverage]
    public class EventViewerHelper: IEventViewerHelper
    {
        public IEnumerable<EventView> GetEventViewList(string logName, string date, string limit)
        {
            List<EventView> listEventView = new List<EventView>();
            EventLog eventLog = new EventLog(logName);
            int total = eventLog.Entries.Count;

            int maxResults = limit == "*" ? int.MaxValue : Convert.ToInt32(limit);

            for (int i = total - 1; i >= 0 && listEventView.Count < maxResults; i--)
            {
                var entry = eventLog.Entries[i];
                if (entry.TimeGenerated.ToString("yyyy-MM-dd") == date)
                {
                    listEventView.Add(new EventView
                    {
                        EntryType = entry.EntryType.ToString(),
                        Source = entry.Source,
                        Message = entry.Message,
                        TimeGenerated = entry.TimeGenerated.ToString("yyyy-MM-dd HH:mm:ss"),
                    });
                }
            }
            return listEventView;
        }
    }
}
