using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISDP2025_jared_green_web.Server.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginService;
        private readonly IJsonWebToken _jwtService;
        private readonly IEmployees _employeeService;

        public LoginController(ILogin loginService, IJsonWebToken jwtService, IEmployees employeeService)
        {
            _loginService = loginService;
            _jwtService = jwtService;
            _employeeService = employeeService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
                return BadRequest("Invalid login request.");

            var success = await _loginService.AttemptLogin(loginRequest.Email, loginRequest.Password);
            if (!success)
                return Unauthorized("Login failed.");

            var employee = await _employeeService.GetEmployeeByEmail(loginRequest.Email);
            if (employee == null)
                return NotFound("Employee not found.");

            var roles = employee.Employeeroles
                .Where(r => r.Active != 0)
                .Select(r => r.Position.PermissionLevel)
                .ToList();

            var token = _jwtService.GenerateToken(employee.Username, roles);

            return Ok(new { token });
        }
    }
}
