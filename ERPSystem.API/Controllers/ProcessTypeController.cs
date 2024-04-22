using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.InvoiceDTO;
using ERPSystem.Entity.DTO.ProcessTypeDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessTypeController : ControllerBase
    {
        private readonly IProcessTypeService _processTypeService;

        public ProcessTypeController(IProcessTypeService processTypeService)
        {
            _processTypeService = processTypeService;
        }

        [HttpPost("/ProcessTypes")]
        public async Task<IActionResult> GetAllAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            var processTypes = await _processTypeService.GetAllAsync(processTypeDTORequest);

            return Ok(processTypes);
        }

        [HttpPost("/ProcessType")]
        public async Task<IActionResult> GetAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            var processType = await _processTypeService.GetAsync(processTypeDTORequest);

            return Ok(processType);
        }

        [HttpPost("/AddProcessType")]
        public async Task<IActionResult> AddAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            var addedProcessType = await _processTypeService.AddAsync(processTypeDTORequest);

            return Ok($"{addedProcessType.Name}+{addedProcessType.Id} 'li İşlem Tipi Eklendi! ");
        }

        [HttpPost("/UpdateProcessType")]
        public async Task<IActionResult> UpdateAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            await _processTypeService.UpdateAsync(processTypeDTORequest);
            return Ok("İşlem Başarılı!!");
        }

        [HttpPost("/DeleteProcessType")]
        public async Task<IActionResult> DeleteAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            await _processTypeService.DeleteAsync(processTypeDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
