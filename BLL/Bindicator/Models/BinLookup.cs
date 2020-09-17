using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace House.HLL.Models
{
    public class BinLookup
    {
        public Bin Rubbish { get; set; }
        public Bin Recycling { get; set; }
        public Bin FoodWaste { get; set; }

        public BinLookup(BinLookupDto dto)
        {
            Rubbish = new Bin(dto.Rubbish);
            Recycling = new Bin(dto.Recycling);
            FoodWaste = new Bin(dto.FoodWaste);
        }
    }

    public class BinLookupDto
    {
        public BinDto Rubbish { get; set; }
        public BinDto Recycling { get; set; }
        public BinDto FoodWaste { get; set; }
    }
}
