using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract;
using ERPSystem.Entity.DTO.CompanyDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("/Companies")]
        public async Task<IActionResult> GetAllAsync(CompanyDTORequest companyDTORequest)
        {
            var companies = await _companyService.GetAllAsync(companyDTORequest);
            return Ok(companies);
        }

        [HttpPost("/Company")]
        public async Task<IActionResult> GetAsync(CompanyDTORequest companyDTORequest)
        {
            var company = await _companyService.GetAsync(companyDTORequest);
            return Ok(company);
        }


        [HttpPost("/AddCompany")]
        public async Task<IActionResult> AddAsync(CompanyDTORequest companyDTORequest)
        {
            var company = await _companyService.AddAsync(companyDTORequest);
            return Ok($"Yeni Bir Şirket Eklendi =>\n\r Name: {company.Name} Id: {company.Id}");
        }

        [HttpPost("/UpdateCompany")]
        public async Task<IActionResult> UpdateAsync(CompanyDTORequest companyDTORequest)
        {
            await _companyService.UpdateAsync(companyDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }
    }
}
