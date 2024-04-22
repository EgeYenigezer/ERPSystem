using AutoMapper;
using ERPSystem.Entity.DTO.StockDetailDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.StockDetailMapper
{
    public class StockDetailResponseMapper:Profile
    {
        public StockDetailResponseMapper()
        {
            CreateMap<StockDetail, StockDetailDTOResponse>().ForMember(dest => dest.StockName, opt =>
            {
                opt.MapFrom(src=>src.Stock.Product.Name);
            }).ForMember(dest => dest.ProcessTypeName, opt =>
            {
                opt.MapFrom(src=>src.ProcessType.Name);
            }).
            ForMember(dest => dest.RecieverName, opt =>
            {
                opt.MapFrom(src=>src.Receiver.Name);
            }).
            ForMember(dest => dest.DelivererName, opt =>
            {
                opt.MapFrom(src=>src.Deliverer.Name);
            }).ReverseMap();
        }
    }
}
