using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.UserDTO;
using ERPSystem.Entity.DTO.UserRoleDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("/UserRoles")]
        public async Task<IActionResult> GetAllAsync(UserRoleDTORequest userRoleDTORequest)
        {
            var userRoles = await _userRoleService.GetAllAsync(userRoleDTORequest);
            return Ok(userRoles);
        }

        [HttpPost("/UserRole")]
        public async Task<IActionResult> GetAsync(UserRoleDTORequest userRoleDTORequest)
        {
            var userRole = await _userRoleService.GetAsync(userRoleDTORequest);
            return Ok(userRole);
        }

        [HttpPost("/AddUserRole")]
        public async Task<IActionResult> AddAsync(UserRoleDTORequest userRoleDTORequest)
        {
            var addedUserRole = await _userRoleService.AddAsync(userRoleDTORequest);
            return Ok($"Yeni Bir UserRole Eklendi =>\n\r Name: {addedUserRole.UserName + addedUserRole.RoleName} Id: {addedUserRole.Id}");
        }

        [HttpPost("/UpdateUserRole")]
        public async Task<IActionResult> UpdateAsync(UserRoleDTORequest userRoleDTORequest)
        {
            await _userRoleService.UpdateAsync(userRoleDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteUserRole")]
        public async Task<IActionResult> DeleteAsync(UserRoleDTORequest userRoleDTORequest)
        {
            await _userRoleService.DeleteAsync(userRoleDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
