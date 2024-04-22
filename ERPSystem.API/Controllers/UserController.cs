using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.UnitDTO;
using ERPSystem.Entity.DTO.UserDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/Users")]
        public async Task<IActionResult> GetAllAsync(UserDTORequest userDTORequest)
        {
            var users = await _userService.GetAllAsync(userDTORequest);
            return Ok(users);
        }

        [HttpPost("/User")]
        public async Task<IActionResult> GetAsync(UserDTORequest userDTORequest)
        {
            var user = await _userService.GetAsync(userDTORequest);
            return Ok(user);
        }

        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddAsync(UserDTORequest userDTORequest)
        {
            var addedUser = await _userService.AddAsync(userDTORequest);
            return Ok($"Yeni Bir Kullanıcı Eklendi =>\n\r Name: {addedUser.Name} Id: {addedUser.Id}");
        }

        [HttpPost("/UpdateUser")]
        public async Task<IActionResult> UpdateAsync(UserDTORequest userDTORequest)
        {
            await _userService.UpdateAsync(userDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteUser")]
        public async Task<IActionResult> DeleteAsync(UserDTORequest userDTORequest)
        {
            await _userService.DeleteAsync(userDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
