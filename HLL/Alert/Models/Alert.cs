using System;
using House.DAL.DataTransferObjects;

namespace House.HLL.Alert.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }

        public Alert(AlertDto dto)
        {
            Id = dto.Id;
            Message = dto.Message;
            DateCreated = dto.DateCreated;
            CreatedBy = dto.CreatedBy;
        }
    }
}
