using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Constants;
using webApi.Infrastructure;
using webApi.Model;
using webApi.Services.Users;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        private readonly IUsersInterface usersContext;

        public readonly  IConfiguration _config;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUsersInterface users,IConfiguration config,ILogger<UsersController> logger)
        {

            usersContext = users;
            _config = config;
            this.logger = logger;
        }
          
       
        [HttpGet("internal")]
        public ActionResult<List<UsersDTO>> GetusersSample()
        { 
            return usersContext.GetAllUsersByCache();
        }

        [HttpGet("cacheData")]
        public ActionResult<List<UsersDTO>> GetusersSampleCache()
        {
            return usersContext.GetAllUsersByCache();
        }

        [HttpGet("external")]
        public  ActionResult<ExternalUserDTO>  GetusersExternal()
        {
            return usersContext.GetUserExternal();
        }

        // GET: api/Users/5
        [HttpGet("uniqueUser")]
        [Authorize(Policy = PolicyConstants.requireRoleAdmin)]
        public   ActionResult<UsersModel> GetUsers([FromQuery] int id)
        {
            var users = usersContext.GetUser(id);
            
                if (users == null)
                {
                    return NotFound();
                }
            return Ok(users);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("updateUser")]
        public  IActionResult PutUsers([FromQuery] int id, UsersUpdateDTO users)
        {

            var updatedUser = usersContext.UpdateUsers(id, users);
             
            if(!updatedUser.IsSuccess)
            {
                return BadRequest("some things wrong happen");
            }

            return Ok(updatedUser);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("newUser")]
        public  ActionResult  PostUsers(UsersDTO users)
        {

           var result =usersContext.AddNewUsers(users);
            if (!result.IsSuccess)
                throw new Exception("Internal Server Error");
           return Ok(result);
        }

        //DELETE: api/Users/5
        [HttpDelete("RemoveUser")]
        public  IActionResult DeleteUsers([FromQuery] int id)
        {
            var users = usersContext.DeleteUsers(id);
            if (users == null)
            {
                return NotFound();
            }      

            return Ok(users);
        }

        [HttpPost("userExist")]
        public ActionResult<bool> UsersExists([FromQuery] int id)
        {
            var exist = usersContext.checkUserExist(id);
            return Ok(exist);
        }
    }
}
