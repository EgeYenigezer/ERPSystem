using AutoMapper;
using ERPSystem.Entity.DTO.InvoiceDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.InvoiceMapper
{
    public class InvoiceResponseMapper:Profile
    {
        public InvoiceResponseMapper()
        {
            CreateMap<Invoice,InvoiceDTOResponse>();
            CreateMap<InvoiceDTOResponse, Invoice>();
        }
    }
}
