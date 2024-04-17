using ERPSystem.Entity.DTO.InvoiceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface IInvoiceService:IGenericService<InvoiceDTORequest, InvoiceDTOResponse>
    {
    }
}
