using System;

namespace House.DAL.DataTransferObjects
{
    public class UniEventDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EventType { get; set; }
        public int Unit { get; set; }
        public string EventLeader { get; set; }
        public int Id { get; set; }
    }
}
