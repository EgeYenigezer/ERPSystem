using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.ProductDTO;
using ERPSystem.Entity.DTO.RequestDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService productService)
        {
            _requestService = productService;
        }

        [HttpPost("/Requests")]
        public async Task<IActionResult> GetAllAsync(RequestDTORequest requestDTORequest)
        {
            var requests = await _requestService.GetAllAsync(requestDTORequest);
            return Ok(requests);
        }

        [HttpPost("/Request")]
        public async Task<IActionResult> GetAsync(RequestDTORequest requestDTORequest)
        {
            var request = await _requestService.GetAsync(requestDTORequest);
            return Ok(request);
        }

        [HttpPost("/AddRequest")]
        public async Task<IActionResult> AddAsync(RequestDTORequest requestDTORequest)
        {
            var addedRequest = await _requestService.AddAsync(requestDTORequest);
            return Ok($"Yeni Bir İstek Eklendi =>\n\r Name: {addedRequest.Title} Id: {addedRequest.Id}");
        }

        [HttpPost("/UpdateRequest")]
        public async Task<IActionResult> UpdateAsync(RequestDTORequest requestDTORequest)
        {
            await _requestService.UpdateAsync(requestDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteRequest")]
        public async Task<IActionResult> DeleteAsync(RequestDTORequest requestDTORequest)
        {
            await _requestService.DeleteAsync(requestDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
