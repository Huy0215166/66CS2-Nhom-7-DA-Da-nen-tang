using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Explora.dto;
using Explora.data;
using Explora.Entity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Explora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private ExploraContext context;
        public UsersController(ExploraContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpGet("Get-all")]
        public IActionResult GetAllUser()
        {
            var user = context.TUsers.Select(u => new UserDto
            {
                Id = u.UserId,
                Name = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                DateOfBirth = u.DateOfBirth,
                UrlAvatar = u.UrlAvatar,
            });
            return Ok(new { user });
        }
        [HttpGet("Get-by-ID/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = context.TUsers.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new { user });
        }
        [HttpPut("Update/{id}")]
        public IActionResult UpdateUserById(int id, UpdateUserDto dataUpdate)
        {
            var user = context.TUsers.FirstOrDefault(u => u.UserId == id);
            if ( user == null)
            {
                return NotFound();
            }
            user.UserName = dataUpdate.Name;
            user.DateOfBirth = dataUpdate.DateOfBirth;
            user.PasswordUser = dataUpdate.Password;
            context.SaveChanges();
            return Ok(new { user });
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetUserByToken()
        {
            var UserId = Int32.Parse(User.FindFirst("Id")?.Value ?? "0");
            var user = context.TUsers.FirstOrDefault(u => u.UserId == UserId);
            return Ok(user);
        }

    }
}

    