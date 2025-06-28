using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
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
            return "token";
        }
        private UserData ValidateCredential(AuthenticationData data) 
        {
            if(CompareValues(data.UserName,"ht") && CompareValues(data.Password,"858585"))
            {
                return new UserData(1, data.UserName );
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
