using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using TakeawayAPI.Data;
using TakeawayAPI.Data.DTOs;
using TakeawayAPI.Data.Models;
using TakeawayAPI.Services;

namespace TakeawayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;
        public AccountsController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, TokenService tokenService)
        {
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<LoginResult>> Regiset(RegisterRequest registerRequest)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerRequest.Email)) return BadRequest("Email is exist.");

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerRequest.UserName)) return BadRequest("User Name is exist");

            if (!ModelState.IsValid) return BadRequest("The length of the password should be more than 8");

            var user = new ApplicationUser()
            {
                Email = registerRequest.Email.ToLower(),
                UserName = registerRequest.UserName,
                Address = registerRequest.Address,
            };
            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            return new LoginResult
            {
                Success = true,
                Message = "Register successful.",
                Email = user.Email,
                UserName = user.UserName,
                Token = await _tokenService.GenerateToken(user)
            };

        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            // could be FindByName
            if (user == null
                || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
                return Unauthorized(new LoginResult()
                {
                    Success = false,
                    Message = "Invalid Email or Password"
                });

            await _userManager.AddToRoleAsync(user, "Customer");
            return Ok(new LoginResult()
            {
                Success = true,
                Message = "login Successful",
                Email = user.Email,
                UserName = user.UserName,
                Token = await _tokenService.GenerateToken(user)
            });
        }
    }
}
