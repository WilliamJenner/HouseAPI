using House.HLL.Common;
using RestSharp;

namespace House.HLL.UniEvent.Interfaces
{
    public interface IUniEventServiceAgent
    {
        IRestResponse GetTimetableEvents(KeyValue cookie);
    }
}