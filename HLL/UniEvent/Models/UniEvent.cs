using System;
using House.DAL.DataTransferObjects;

namespace House.HLL.UniEvent.Models
{
    public class UniEvent
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public UniEventType EventType { get; set; }
        public Unit Unit { get; set; }
        public string EventLeader { get; set; }
        public int Id { get; set; }

        public UniEvent(UniEventDto dto)
        {
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
            EventType = (UniEventType) dto.EventType;
            Unit = (Unit) dto.Unit;
            EventLeader = dto.EventLeader;
            Id = dto.Id;
        }
    }
}
