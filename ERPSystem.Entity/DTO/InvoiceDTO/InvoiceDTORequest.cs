using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.InvoiceDTO
{
    public class InvoiceDTORequest:BaseRequestDTO
    {
        public Int64 Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string SupplierName { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
    }
}
