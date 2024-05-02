﻿using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.StockDetailDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class StockDetailManager : IStockDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StockDetailManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<StockDetailDTOResponse> AddAsync(StockDetailDTORequest RequestEntity)
        {
            var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
            var addedStockDetail = await _uow.StockDetailRepository.AddAsync(stockDetail);
            await _uow.SaveChangeAsync();
            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(addedStockDetail.Entity);
            return stockDetailDTOResponse;
        }

        public async Task DeleteAsync(StockDetailDTORequest RequestEntity)
        {
            var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
            await _uow.StockDetailRepository.RemoveAsync(stockDetail);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<StockDetailDTOResponse>> GetAllAsync(StockDetailDTORequest RequestEntity)
        {
            if (RequestEntity.StockId!=0)
            {
                var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
                var dbStockDetails = await _uow.StockDetailRepository.GetAllAsync(x=>x.StockId==stockDetail.StockId,"Stock.Product","ProcessType","Receiver","Deliverer");

                List<StockDetailDTOResponse> stockDetailDTOResponses = new();

                foreach (var dbStockDetail in dbStockDetails)
                {
                    stockDetailDTOResponses.Add(_mapper.Map<StockDetailDTOResponse>(dbStockDetail));
                }
                return stockDetailDTOResponses;
            }
            else if (RequestEntity.ProcessTypeId!=0)
            {
                var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
                var dbStockDetails = await _uow.StockDetailRepository.GetAllAsync(x => x.ProcessTypeId == stockDetail.ProcessTypeId, "Stock.Product", "ProcessType","Receiver", "Deliverer");

                List<StockDetailDTOResponse> stockDetailDTOResponses = new();

                foreach (var dbStockDetail in dbStockDetails)
                {
                    stockDetailDTOResponses.Add(_mapper.Map<StockDetailDTOResponse>(dbStockDetail));
                }
                return stockDetailDTOResponses;
            }
            else if(RequestEntity.DelivererId !=0)
            {
                var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
                var dbStockDetails = await _uow.StockDetailRepository.GetAllAsync(x => x.DelivererId == stockDetail.DelivererId, "Stock.Product", "ProcessType", "Receiver", "Deliverer");

                List<StockDetailDTOResponse> stockDetailDTOResponses = new();

                foreach (var dbStockDetail in dbStockDetails)
                {
                    stockDetailDTOResponses.Add(_mapper.Map<StockDetailDTOResponse>(dbStockDetail));
                }
                return stockDetailDTOResponses;
            }
            else
            {
                
                var dbStockDetails = await _uow.StockDetailRepository.GetAllAsync(x=>true, "Stock.Product", "ProcessType", "Receiver", "Deliverer");

                List<StockDetailDTOResponse> stockDetailDTOResponses = new();

                foreach (var dbStockDetail in dbStockDetails)
                {
                    stockDetailDTOResponses.Add(_mapper.Map<StockDetailDTOResponse>(dbStockDetail));
                }
                return stockDetailDTOResponses;
            }
        }

        public async Task<StockDetailDTOResponse> GetAsync(StockDetailDTORequest RequestEntity)
        {
            var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
            var dbStockDetail = await _uow.StockDetailRepository.GetAsync(x=>x.Id==stockDetail.Id, "Stock.Product", "ProcessType", "Receiver", "Deliever");

            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(dbStockDetail);

            return stockDetailDTOResponse;
        }

        public async Task UpdateAsync(StockDetailDTORequest RequestEntity)
        {
            var stockDetail = await _uow.StockDetailRepository.GetAsync(x=>x.Id==RequestEntity.Id);
            if (RequestEntity.StockId == 0)
            {
                RequestEntity.StockId = stockDetail.StockId;
            }
            stockDetail = _mapper.Map(RequestEntity,stockDetail);
            await _uow.StockDetailRepository.UpdateAsync(stockDetail);
            await _uow.SaveChangeAsync();
        }
    }
}
