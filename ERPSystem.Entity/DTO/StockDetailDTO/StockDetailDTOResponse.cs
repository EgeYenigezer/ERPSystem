using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.StockDetailDTO
{
    public class StockDetailDTOResponse
    {
        public Int64 Id { get; set; }
        public decimal Quantity { get; set; }
        public string StockName { get; set; }
        public string ProcessTypeName { get; set; }
        public string RecieverName { get; set; }
        public string DelivererName { get; set; }
    }
}
