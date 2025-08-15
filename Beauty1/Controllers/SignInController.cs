using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Beauty1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Beauty1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SignInController : ControllerBase
    {
        private const string TokenSecret = "odawdioadioapeapiapidjawpdajpdijadpaiwjdwaiodjajdpawiodaiclksamdwowadwdwad";
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(1);

        private readonly CustomContext _custom;

        public SignInController(CustomContext custom)
        {
            _custom = custom;
        }

        [HttpPost("token")]
        public string GenerateToken([FromBody] SignIn signIn)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signIn.UserName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                Issuer = "https://localhost:7102",
                Audience = "https://localhost:7102",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            if(token != null)
            {
                var jwt = tokenHandler.WriteToken(token);
                return jwt;
            }
            else
            {
                return "Failed to create token";
            }

        }

        [HttpPost("login")]

        public IActionResult Login([FromBody] SignIn signIn)
        {
            SignIn? ss = _custom.SignIns.FirstOrDefault(u => u.UserName == signIn.UserName && u.Password == signIn.Password);
            string bearerToken = "";
            if(ss == null)
            {
                return Unauthorized();
            }
            try
            {
                bearerToken = GenerateToken(ss);
            }
            catch
            {
                return StatusCode(500);
            }


            return Ok(new
            {
                Stutus = "200",
                Message = "Success",
                tokne = bearerToken   
            });
        }

        [HttpPost("Register")]
        public ActionResult Register(SignIn sign)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            sign.Register(_custom);
            _custom.SaveChanges();
            return Ok(sign.UserName);
        }
    }
}
