namespace House.DAL.DataTransferObjects
{
    using System;

    public class AlertDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public bool Expired { get; set; }
    }
}
