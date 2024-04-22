using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.CategoryDTO;
using ERPSystem.Entity.DTO.CompanyDTO;
using ERPSystem.Entity.DTO.DepartmentDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("/Categories")]
        public async Task<IActionResult> GetAllAsync(CategoryDTORequest categoryDTORequest)
        {
            var categories = await _categoryService.GetAllAsync(categoryDTORequest);
            return Ok(categories);
        }

        [HttpPost("/Category")]
        public async Task<IActionResult> GetAsync(CategoryDTORequest categoryDTORequest)
        {
            var category = await _categoryService.GetAsync(categoryDTORequest);
            return Ok(category);
        }


        [HttpPost("/AddCategory")]
        public async Task<IActionResult> AddAsync(CategoryDTORequest categoryDTORequest)
        {
            var category = await _categoryService.AddAsync(categoryDTORequest);
            return Ok($"Yeni Bir Şirket Eklendi =>\n\r Name: {category.Name} Id: {category.Id}");
        }

        [HttpPost("/UpdateCategory")]
        public async Task<IActionResult> UpdateAsync(CategoryDTORequest categoryDTORequest)
        {
            await _categoryService.UpdateAsync(categoryDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteCategory")]
        public async Task<IActionResult> DeleteAsync(CategoryDTORequest categoryDTORequest)
        {
            await _categoryService.DeleteAsync(categoryDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }
    }
}
