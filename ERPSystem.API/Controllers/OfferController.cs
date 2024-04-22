using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.OfferDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost("/Offers")]
        public async Task<IActionResult> GetAllAsync(OfferDTORequest offerDTORequest)
        {
            var offers = await _offerService.GetAllAsync(offerDTORequest);
            return Ok(offers);
        }

        [HttpPost("/Offer")]
        public async Task<IActionResult> GetAsync(OfferDTORequest offerDTORequest)
        {
            var offer = await _offerService.GetAsync(offerDTORequest);
            return Ok(offer);
        }

        [HttpPost("/AddOffer")]
        public async Task<IActionResult> AddAsync(OfferDTORequest offerDTORequest)
        {
            var addedOffer = await _offerService.AddAsync(offerDTORequest);
            return Ok($"{addedOffer.SupplierName} adlı tedarikçinin teklifi sisteme eklendi.");
        }

        [HttpPost("/UpdateOffer")]
        public async Task<IActionResult> UpdateAsync(OfferDTORequest offerDTORequest)
        {
            await _offerService.UpdateAsync(offerDTORequest);
            return Ok("İşlem Başarılı!!");
        }

        [HttpPost("/DeleteOffer")]
        public async Task<IActionResult> DeleteAsync(OfferDTORequest offerDTORequest)
        {
            await _offerService.DeleteAsync(offerDTORequest);
            return Ok("İşlem Başarılı");

        }

    }
}
