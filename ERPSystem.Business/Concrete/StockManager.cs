using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.StockDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class StockManager : IStockService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StockManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<StockDTOResponse> AddAsync(StockDTORequest RequestEntity)
        {
            var stock = _mapper.Map<Stock>(RequestEntity);
            var addedStock = await _uow.StockRepository.AddAsync(stock);
            await _uow.SaveChangeAsync();
            StockDTOResponse stockDTOResponse = _mapper.Map<StockDTOResponse>(addedStock.Entity);
            return stockDTOResponse;
        }

        public async Task DeleteAsync(StockDTORequest RequestEntity)
        {
            var stock = _mapper.Map<Stock>(RequestEntity);
            await _uow.StockRepository.RemoveAsync(stock);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<StockDTOResponse>> GetAllAsync(StockDTORequest RequestEntity)
        {
            if (RequestEntity.ProductId!=null)
            {
                var stock = _mapper.Map<Stock>(RequestEntity);
                var dbStocks =await _uow.StockRepository.GetAllAsync(x=>x.ProductId==stock.ProductId);

                List<StockDTOResponse> stockDTOResponses = new();
                foreach(var dbStock in dbStocks)
                {
                    stockDTOResponses.Add(_mapper.Map<StockDTOResponse>(dbStock));
                }
                return stockDTOResponses;
            }
            else if (RequestEntity.DepartmentId!=null)
            {
                var stock = _mapper.Map<Stock>(RequestEntity);
                var dbStocks = await _uow.StockRepository.GetAllAsync(x => x.DepartmentId == stock.DepartmentId);

                List<StockDTOResponse> stockDTOResponses = new();
                foreach (var dbStock in dbStocks)
                {
                    stockDTOResponses.Add(_mapper.Map<StockDTOResponse>(dbStock));
                }
                return stockDTOResponses;
            }
            else
            {
                var dbStocks = await _uow.StockRepository.GetAllAsync();

                List<StockDTOResponse> stockDTOResponses = new();
                foreach (var dbStock in dbStocks)
                {
                    stockDTOResponses.Add(_mapper.Map<StockDTOResponse>(dbStock));
                }
                return stockDTOResponses;
            }
        }

        public async Task<StockDTOResponse> GetAsync(StockDTORequest RequestEntity)
        {
            var stock = _mapper.Map<Stock>(RequestEntity);
            var dbStock = await _uow.StockRepository.GetAsync(x=>x.Id==stock.Id);
            StockDTOResponse stockDTOResponse = _mapper.Map<StockDTOResponse>(dbStock);
            return stockDTOResponse;

        }

        public async Task UpdateAsync(StockDTORequest RequestEntity)
        {
            var stock = _mapper.Map<Stock>(RequestEntity);
            await _uow.StockRepository.UpdateAsync(stock);
            await _uow.SaveChangeAsync();
        }
    }
}
