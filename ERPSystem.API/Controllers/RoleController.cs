using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.RequestDTO;
using ERPSystem.Entity.DTO.RoleDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("/Roles")]
        public async Task<IActionResult> GetAllAsync(RoleDTORequest roleDTORequest)
        {
            var roles = await _roleService.GetAllAsync(roleDTORequest);
            return Ok(roles);
        }

        [HttpPost("/Role")]
        public async Task<IActionResult> GetAsync(RoleDTORequest roleDTORequest)
        {
            var role = await _roleService.GetAsync(roleDTORequest);
            return Ok(role);
        }

        [HttpPost("/AddRole")]
        public async Task<IActionResult> AddAsync(RoleDTORequest roleDTORequest)
        {
            var addedRole = await _roleService.AddAsync(roleDTORequest);
            return Ok($"Yeni Bir Rol Eklendi =>\n\r Name: {addedRole.Name} Id: {addedRole.Id}");
        }

        [HttpPost("/UpdateRole")]
        public async Task<IActionResult> UpdateAsync(RoleDTORequest roleDTORequest)
        {
            await _roleService.UpdateAsync(roleDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteRole")]
        public async Task<IActionResult> DeleteAsync(RoleDTORequest roleDTORequest)
        {
            await _roleService.DeleteAsync(roleDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
