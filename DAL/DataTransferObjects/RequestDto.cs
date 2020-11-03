namespace House.DAL.DataTransferObjects
{
    using System;

    public class RequestDto
    {
        public int Id { get; set; }
        public string Requester { get; set; }
        public decimal RequestedAmount { get; set; }
        public bool Expired { get; set; }
    }
}
