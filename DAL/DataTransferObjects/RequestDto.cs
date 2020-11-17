namespace House.DAL.DataTransferObjects
{
    public class RequestDto
    {
        public int Id { get; set; }
        public string Requester { get; set; }
        public decimal RequestedAmount { get; set; }
        public bool Expired { get; set; }
    }
}
