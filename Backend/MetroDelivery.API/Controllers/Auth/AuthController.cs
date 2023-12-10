using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Contracts.Identity;
using MetroDelivery.Application.Features.Auth.Queries.ChangePassword;
using MetroDelivery.Application.Features.Auth.Queries.ResetPassword;
using MetroDelivery.Application.Models.Identity;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Auth
{
    [Route("api/v1/auths")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public AuthController(IAuthService authenticationService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMediator mediator)
        {
            this._authenticationService = authenticationService;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
            this._mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            if (User.Identity.IsAuthenticated) {
                return BadRequest("You have logged in.");
            }
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<AuthenticationResultResponse>> GetRefreshToken(AuthenticationResult request)
        {
            if (User.Identity.IsAuthenticated) {
                return BadRequest("You have logged in.");
            }
            return Ok(await _authenticationService.Refresh(request));
        }

        [HttpPost("register-user")]
        public async Task<ActionResult<RegistrationResponse>> RegisterUser(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegistrationRequest request)
        {
            var emailExist = await _userManager.FindByEmailAsync(request.Email);
            if (emailExist != null) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Email already existed!");
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = true,
                Created = DateTime.Now

            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Admin Create Fail");
            }

            if (!await _roleManager.RoleExistsAsync("Admin")) {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await _roleManager.RoleExistsAsync("Staff")) {
                await _roleManager.CreateAsync(new IdentityRole("Staff"));
            }
            if (!await _roleManager.RoleExistsAsync("EndUser")) {
                await _roleManager.CreateAsync(new IdentityRole("EndUser"));
            }
            if (await _roleManager.RoleExistsAsync("Admin")) {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return Ok("Admin create Succesfully");
        }

        [HttpPost]
        [Route("register-staff")]
        public async Task<IActionResult> RegisterStaff([FromBody] RegistrationRequest request)
        {
            var emailExist = await _userManager.FindByEmailAsync(request.Email);
            if (emailExist != null) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Email already existed!");
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = true,
                Created = DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Staff create Fail");
            }

            if (!await _roleManager.RoleExistsAsync("Admin")) {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await _roleManager.RoleExistsAsync("Staff")) {
                await _roleManager.CreateAsync(new IdentityRole("Staff"));
            }
            if (!await _roleManager.RoleExistsAsync("EndUser")) {
                await _roleManager.CreateAsync(new IdentityRole("EndUser"));
            }
            if (await _roleManager.RoleExistsAsync("Staff")) {
                await _userManager.AddToRoleAsync(user, "Staff");
            }

            return Ok("Staff create Succesfully");
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordQuery request)
        {
            try {
                var result = await _mediator.Send(new ResetPasswordQuery { Email = request.Email });

                return Ok(result);
            }
            catch (Exception ex) {
                /*_logger.LogError(ex, "User not found");*/
                throw new BadRequestException("User does not exist.");
            }
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordQuery request)
        {
            try {

                var result = await _mediator.Send(new ChangePasswordQuery
                {
                    Email = request.Email ?? "",
                    CurrentPassword = request.CurrentPassword ?? "",
                    NewPassword = request.NewPassword ?? ""
                });

                return Ok(result);
            }
            catch (Exception ex) {
                if (ex is ValidationException) {
                    ValidationException error = (ValidationException)ex;
                    var errorsDiction = new Dictionary<string, string[]>(error.Errors);
                    return BadRequest(errorsDiction);
                }
                return BadRequest(ex.Message);
            }
        }
    }
}
