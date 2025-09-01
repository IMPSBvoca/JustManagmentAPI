using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JustManagmentApi.Core.Entities;
using JustManagmentApi.Core.Interfaces;
using JustManagmentApi.Infrastructure.Repositories;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace JustManagmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;

        public UserController(IUsersRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() 
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user) 
        {
            await _userRepository.AddUserAsync(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(User user) 
        {
            var allUsers = await _userRepository.GetAllUsersAsync();
            var curUser = allUsers.Where(n => n.FirstName == user.FirstName && n.LastName == user.LastName).FirstOrDefault();
            await _userRepository.DeleteUserAsync(curUser);
            return Ok();
        }
    }
}
