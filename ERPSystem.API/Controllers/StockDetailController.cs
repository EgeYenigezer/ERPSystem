using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.StockDetailDTO;
using ERPSystem.Entity.DTO.StockDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDetailController : ControllerBase
    {
        private readonly IStockDetailService _stockDetailService;

        public StockDetailController(IStockDetailService stockDetailService)
        {
            _stockDetailService = stockDetailService;
        }

        [HttpPost("/StockDetails")]
        public async Task<IActionResult> GetAllAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            var stockDetails = await _stockDetailService.GetAllAsync(stockDetailDTORequest);
            return Ok(stockDetails);
        }

        [HttpPost("/StockDetail")]
        public async Task<IActionResult> GetAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            var stockDetail = await _stockDetailService.GetAsync(stockDetailDTORequest);
            return Ok(stockDetail);
        }

        [HttpPost("/AddStockDetail")]
        public async Task<IActionResult> AddAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            var addedStockDetail = await _stockDetailService.AddAsync(stockDetailDTORequest);
            return Ok($"Yeni Bir Stok Detayı Eklendi =>\n\r Name: {addedStockDetail.StockName} Id: {addedStockDetail.Id}");
        }

        [HttpPost("/UpdateStockDetail")]
        public async Task<IActionResult> UpdateAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            await _stockDetailService.UpdateAsync(stockDetailDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteStockDetail")]
        public async Task<IActionResult> DeleteAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            await _stockDetailService.DeleteAsync(stockDetailDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
