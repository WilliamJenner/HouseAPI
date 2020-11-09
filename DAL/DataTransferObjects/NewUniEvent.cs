namespace House.DAL.DataTransferObjects
{
    using System;

    public class NewUniEvent
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EventType { get; set; }
        public int Unit { get; set; }
        public string EventLeader { get; set; }
    }
}
