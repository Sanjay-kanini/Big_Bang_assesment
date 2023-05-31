
using Big_Bang_assesment.DB;
using Big_Bang_assesment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BIGBANG_ASSESSMENT.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly HotelContext _context;

        private const string GuestRole = "Guest";
       
        public TokenController(IConfiguration config, HotelContext context)
        {
            _configuration = config;
            _context = context;
        }


        [HttpPost("Guest")]
        
        public async Task<IActionResult> PostCustomer(Guest _userData)
        {
            if (_userData != null && _userData.Guest_email != null && _userData.Guest_pwd != null)
            {
                var user = await GetCustomers(_userData.Guest_email, _userData.Guest_pwd);

                if (user != null)
                {

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("Guest_Id", user.Guest_Id.ToString()),
                         new Claim("Guest_email", user.Guest_email),
                        new Claim("Guest_pwd",user.Guest_pwd),
                       new Claim(ClaimTypes.Role, GuestRole)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:ValidIssuer"],
                        _configuration["Jwt:ValidAudience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Guest> GetCustomers(string email, string password)
        {
            return await _context.Guests.FirstOrDefaultAsync(u => u.Guest_email == email && u.Guest_pwd == password);
        }
    }
}

