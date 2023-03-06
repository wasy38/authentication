using authentication.back.Models;
using authentication.back.Models.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace authentication.back.Controllers
{
    [ApiController]
    
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly AuthenticationContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, AuthenticationContext context, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public async Task<IResult> Data()
        {
            return Results.Json("123");
        }
            [HttpPost]
        public async Task<IResult> Register(Person p)
        {
            User user = new User();
            user.Email = p.Email;
            user.Password = p.Password;
            user.Name = user.Email;
            var response = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Results.Json(user);
        }

        [HttpPost("loginData")]
        public IResult Login(Person loginData)
        {

            User? person = _context.Users.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);

            if (person is null) return Results.Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };

            var jwt = new JwtSecurityToken(
                    issuer: _configuration["AuthSettings:ISSUER"],
                    audience: _configuration["AuthSettings:AUDIENCE"],
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:KEY"])), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);


            var response = new
            {
                access_token = encodedJwt,
                username = person.Email
            };

            return Results.Json(response);
        }
    }
}