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
        private readonly ILogger<LocationController> _logger;

        public LoginController(ILogin loginService, IJsonWebToken jwtService, IEmployees employeeService, ILogger<LocationController> logger)
        {
            _loginService = loginService;
            _jwtService = jwtService;
            _employeeService = employeeService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
                    return BadRequest("Invalid login request.");

                var success = await _loginService.AttemptLogin(loginRequest.Email, loginRequest.Password);
                if (!success)
                    return Unauthorized("Login failed.");

                var employee = await _employeeService.GetEmployeeByEmail(loginRequest.Email);
                if (employee == null)
                    return NotFound("Employee not found.");

                Employee emp = (employee as Employee);

                var roles = emp.Employeeroles
                    .Where(r => r.Active != 0)
                    .Select(r => r.Position.PermissionLevel)
                    .ToList();

                var token = _jwtService.GenerateToken(emp.Username, roles);

                return Ok(new { token });
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to login");
                return StatusCode(500, "An error occurred while validating login");
            }
        }
    }
}
