using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.StockDetailDTO;
using ERPSystem.Entity.DTO.UnitDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpPost("/Units")]
        public async Task<IActionResult> GetAllAsync(UnitDTORequest unitDTORequest)
        {
            var unitDetails = await _unitService.GetAllAsync(unitDTORequest);
            return Ok(unitDetails);
        }

        [HttpPost("/Unit")]
        public async Task<IActionResult> GetAsync(UnitDTORequest unitDTORequest)
        {
            var unit = await _unitService.GetAsync(unitDTORequest);
            return Ok(unit);
        }

        [HttpPost("/AddUnit")]
        public async Task<IActionResult> AddAsync(UnitDTORequest unitDTORequest)
        {
            var addedUnit = await _unitService.AddAsync(unitDTORequest);
            return Ok($"Yeni Bir Unit Eklendi =>\n\r Name: {addedUnit.Name} Id: {addedUnit.Id}");
        }

        [HttpPost("/UpdateUnit")]
        public async Task<IActionResult> UpdateAsync(UnitDTORequest unitDTORequest)
        {
            await _unitService.UpdateAsync(unitDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteUnit")]
        public async Task<IActionResult> DeleteAsync(UnitDTORequest unitDTORequest)
        {
            await _unitService.DeleteAsync(unitDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
