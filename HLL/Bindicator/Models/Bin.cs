using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.BLL.Bindicator.Models
{
    public class Bin
    {
        public DateTime Subsequent { get; set; }
        public DateTime Next { get; set; }
        public string PdfLink { get; set; }
        public bool Communal { get; set; }

        // For some reason the council has next and previous wrong
        // previous refers to the nearest collection in future
        // next means the collection after previous
        public Bin(BinDto dto)
        {
            Subsequent = dto.Next;
            Next = dto.Previous;
            PdfLink = dto.PdfLink;
            Communal = dto.Communal;
        }
    }

    public class BinDto
    {
        public DateTime Previous { get; set; }
        public DateTime Next { get; set; }
        public string PdfLink { get; set; }
        public bool Communal { get; set; }
    }
}
