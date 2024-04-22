using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.CategoryDTO;
using ERPSystem.Entity.DTO.DepartmentDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("/Departments")]
        public async Task<IActionResult> GetAllAsync(DepartmentDTORequest departmentDTORequest)
        {
            var departments = await _departmentService.GetAllAsync(departmentDTORequest);
            return Ok(departments);
        }

        [HttpPost("/Department")]
        public async Task<IActionResult> GetAsync(DepartmentDTORequest departmentDTORequest)
        {
            var department = await _departmentService.GetAsync(departmentDTORequest);
            return Ok(department);
        }


        [HttpPost("/AddDepartment")]
        public async Task<IActionResult> AddAsync(DepartmentDTORequest departmentDTORequest)
        {
            var department = await _departmentService.AddAsync(departmentDTORequest);
            return Ok($"Yeni Bir Şirket Eklendi =>\n\r Name: {department.Name} Id: {department.Id}");
        }

        [HttpPost("/UpdateDepartment")]
        public async Task<IActionResult> UpdateAsync(DepartmentDTORequest departmentDTORequest)
        {
            await _departmentService.UpdateAsync(departmentDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteDepartment")]
        public async Task<IActionResult> DeleteAsync(DepartmentDTORequest departmentDTORequest)
        {
            await _departmentService.DeleteAsync(departmentDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }
    }
}
