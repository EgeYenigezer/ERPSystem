using AutoMapper;
using ERPSystem.Entity.DTO.StockDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.StockMapper
{
    public class StockResponseMapper:Profile
    {
        public StockResponseMapper()
        {
            CreateMap<Stock,StockDTOResponse>();
            CreateMap<StockDTOResponse, Stock>();
        }
    }
}
