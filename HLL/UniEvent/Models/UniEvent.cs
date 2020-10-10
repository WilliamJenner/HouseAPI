using System;
using System.Collections.Generic;
using House.DAL.DataTransferObjects;

namespace House.HLL.UniEvent.Models
{
    public class UniEvent : IEquatable<UniEvent>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public UniEventType EventType { get; set; }
        public Unit Unit { get; set; }
        public string EventLeader { get; set; }
        public int Id { get; set; }

        public UniEvent()
        {

        }
        public UniEvent(UniEventDto dto)
        {
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
            EventType = (UniEventType) dto.EventType;
            Unit = (Unit) dto.Unit;
            EventLeader = dto.EventLeader;
            Id = dto.Id;
        }

        public bool Equals(UniEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return StartTime.Equals(other.StartTime) && EndTime.Equals(other.EndTime) && EventType == other.EventType && Unit == other.Unit && EventLeader == other.EventLeader;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UniEvent) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartTime, EndTime, (int) EventType, (int) Unit, EventLeader);
        }
    }
}
