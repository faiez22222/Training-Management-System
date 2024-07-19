using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TaskContext _dbcontext;
        private readonly IConfiguration _configuration;
        public LoginController(TaskContext dbcontext , IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]  Login login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticatie(login);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;    
        }

        private string GenerateJSONWebToken(Login login)
        {
            var jwt = _configuration.GetSection("Jwt");
            var key = jwt["Key"];
            var issuser = jwt["Issuser"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey , SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuser, issuser, null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Login Authenticatie(Login login)
        {
            Login obj = _dbcontext.Logins.FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
            return login;
        }




    }
}
