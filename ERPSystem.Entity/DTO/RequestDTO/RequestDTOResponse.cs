using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.RequestDTO
{
    public class RequestDTOResponse
    {
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public string RequesterName { get; set; }
        public string ApproverName { get; set; }
        public string StatusName { get; set; }
    }
}
