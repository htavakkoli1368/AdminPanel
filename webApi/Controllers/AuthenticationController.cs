using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }
        public record AuthenticationData(string? UserName , string? Password);
        public record UserData(int Id , string? UserName);
        [HttpPost("Token")]        
         public ActionResult<string> Authenticate([FromBody] AuthenticationData data)
        {
            var user = ValidateCredential(data);
            if (user == null)
            {
                return Unauthorized();
            }
            var token = GenerateToken(user);
            return Ok(token);
        }
        private string GenerateToken(UserData user)
        {   
            //first create secreteKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Authentication:SecretKey")));

            //singing credential in order to proof and sign our token.it takes 2 item.first one is secretkey that we create
            //last step and choose our securityalgoritm that we choose hmacSha256
            var signingCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List <Claim> claims = new();
            claims.Add(new(JwtRegisteredClaimNames.Sub,user.Id.ToString()));
            claims.Add(new(JwtRegisteredClaimNames.UniqueName,user.UserName));
            claims.Add(new Claim("Role", "Admin"));
            claims.Add(new Claim("IsAdmin", "true"));
       

            var token = new JwtSecurityToken(
                 _config.GetValue<string>("Authentication:Issuer"),
                 _config.GetValue<string>("Authentication:Audience"),
                 claims,
                 DateTime.UtcNow,
                 DateTime.UtcNow.AddSeconds(30),
                 signingCredential
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private UserData ValidateCredential(AuthenticationData data) 
        {
            if(CompareValues(data.UserName,"ht") && CompareValues(data.Password,"858585"))
            {
                return new UserData(1, data.UserName );
            }
            if(CompareValues(data.UserName,"hossein") && CompareValues(data.Password,"696969"))
            {
                return new UserData(2, data.UserName );
            }
            return null; 
        }

        private bool CompareValues(string? actual, string? expected)
        {
            if(actual is not null)
            {
               if(actual.Equals(expected))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
