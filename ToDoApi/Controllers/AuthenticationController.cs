using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthenticationController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public record AuthenticationData(string UserName,string PassWord);
        public record UserData(int Id , string FirstName, string LastName, string UserName);

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> Authenticate([FromBody]AuthenticationData data)
        {
            var user = ValidateCredential(data);
            if (user == null) 
            {
                return Unauthorized();
            }

            string token = GenerateToken(user);
            return Ok(token);
        }

        private string GenerateToken(UserData user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Authentication:SecretKey")));

            var signinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new();

            claims.Add(new(JwtRegisteredClaimNames.Sub,user.Id.ToString()));
            claims.Add(new(JwtRegisteredClaimNames.UniqueName,user.UserName));
            claims.Add(new(JwtRegisteredClaimNames.GivenName,user.FirstName));
            claims.Add(new(JwtRegisteredClaimNames.FamilyName,user.LastName));

            var token = new JwtSecurityToken(
                 _config.GetValue<string>("Authentication:Issuer"),
                 _config.GetValue<string>("Authentication:Audience"),
                 claims,
                 DateTime.UtcNow,
                 DateTime.UtcNow.AddMinutes(1),
                 signinCredential
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserData? ValidateCredential(AuthenticationData data)
        {
           if(CompareValue(data.UserName,"hossein") && CompareValue(data.PassWord, "ht123"))
            {
                return new UserData(Id: 1, FirstName: "hossein", LastName: "tavakkoli", UserName: data.UserName);
            }
            if (CompareValue(data.UserName, "jalal") && CompareValue(data.PassWord, "jalal1370"))
            {
                return new UserData(Id: 2, FirstName: "jalal", LastName: "tavakkoli", UserName: data.UserName);
            }
            return null;
        }
        private bool CompareValue(string actual , string expected)
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
