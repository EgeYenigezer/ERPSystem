using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.StatusDTO;
using ERPSystem.Entity.DTO.StockDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost("/Stocks")]
        public async Task<IActionResult> GetAllAsync(StockDTORequest stockDTORequest)
        {
            var stocks = await _stockService.GetAllAsync(stockDTORequest);
            return Ok(stocks);
        }

        [HttpPost("/Stock")]
        public async Task<IActionResult> GetAsync(StockDTORequest stockDTORequest)
        {
            var stock = await _stockService.GetAsync(stockDTORequest);
            return Ok(stock);
        }

        [HttpPost("/AddStock")]
        public async Task<IActionResult> AddAsync(StockDTORequest stockDTORequest)
        {
            var addedStock = await _stockService.AddAsync(stockDTORequest);
            return Ok($"Yeni Bir Stok Eklendi =>\n\r Name: {addedStock.ProductName + addedStock.UnitName} Id: {addedStock.Id}");
        }

        [HttpPost("/UpdateStock")]
        public async Task<IActionResult> UpdateAsync(StockDTORequest stockDTORequest)
        {
            await _stockService.UpdateAsync(stockDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteStock")]
        public async Task<IActionResult> DeleteAsync(StockDTORequest stockDTORequest)
        {
            await _stockService.DeleteAsync(stockDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
