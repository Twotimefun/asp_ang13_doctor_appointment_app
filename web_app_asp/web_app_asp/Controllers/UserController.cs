using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app_asp.Services;
using web_app_asp.ViewModels;

namespace web_app_asp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or Password is incorrect." });

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            if (_userService.GetUserByEmail(username) != null)
            {
                return BadRequest(new { message = "Email is already registered." });
            }

            _userService.RegisterUser(username, password, "Client");
            return Ok(new { message = "Account successfully Registered" });
        }

        [AdminAuthorize]
        [HttpPost]
        public IActionResult RegisterStaff(string username, string password, string userType)
        {
            if (_userService.GetUserByEmail(username) != null)
            {
                return BadRequest(new { message = "Email has already been registered." });
            }

            _userService.RegisterUser(username, password, userType);
            return Ok(new { message = "Account successfully Registered" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateUser(UserDetails userDetails)
        {
            dynamic user = HttpContext.Items["User"];
            _userService.UpdateUserById(user.UserId, userDetails);
            return Ok(new { message = "Account successfully Registered" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult GetUserByToken()
        {
            dynamic user = HttpContext.Items["User"];
            return Ok(new AuthenticateResponse(_userService.GetUserById(user.UserId), ""));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok(new { message = "Account Deleted" });
        }
    }
}
