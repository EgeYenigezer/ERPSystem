using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.RoleDTO;
using ERPSystem.Entity.DTO.StatusDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpPost("/Statuses")]
        public async Task<IActionResult> GetAllAsync(StatusDTORequest statusDTORequest)
        {
            var statuses = await _statusService.GetAllAsync(statusDTORequest);
            return Ok(statuses);
        }

        [HttpPost("/Status")]
        public async Task<IActionResult> GetAsync(StatusDTORequest statusDTORequest)
        {
            var status = await _statusService.GetAsync(statusDTORequest);
            return Ok(status);
        }

        [HttpPost("/AddStatus")]
        public async Task<IActionResult> AddAsync(StatusDTORequest statusDTORequest)
        {
            var addedStatus = await _statusService.AddAsync(statusDTORequest);
            return Ok($"Yeni Bir Durum Eklendi =>\n\r Name: {addedStatus.Name} Id: {addedStatus.Id}");
        }

        [HttpPost("/UpdateStatus")]
        public async Task<IActionResult> UpdateAsync(StatusDTORequest statusDTORequest)
        {
            await _statusService.UpdateAsync(statusDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteStatus")]
        public async Task<IActionResult> DeleteAsync(StatusDTORequest statusDTORequest)
        {
            await _statusService.DeleteAsync(statusDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
